﻿namespace Game.Core
{
	using Game.Common;
	using Game.Common.CustomEvents;
	using Game.Common.GameOverCheckers;
	using Game.Common.Map;
	using Game.Common.Map.Decorators;
	using Game.Common.Players;
	using Game.Common.Stats;
	using Game.Common.Utils;
	using Game.Core.Actions.ActionProviders;
	using Game.Core.Actions.ActionReceiver;
	using Game.UI;
	using Game.UI.IOProviders;
	using System;

	public delegate void CustomEventHandler(object eventObject);

	/// <summary>
	/// Represents the Core engine.
	/// Implements Observer and Bridge Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Core.IGameEngine"/>
	public class GameEngine : IDefaultGameEngine
	{
		#region Fields

		private bool _gameExit = false;
		private IDefaultUIEngine _uIEngine;
		private IInputProvider _inputProvider;
		private IField _field;
		private IPlayer _player;
		private IIntegerStats _highScores;
		private IMoveable _moveableEntity;
		private IGameOverChecker _gameOverChecker;
		private IActionProvider _actionProvider;
		private IActionReceiver _actionReceiver;

		#endregion Fields

		public GameEngine(IGameEngineSettings<IDefaultUIEngine, IIntegerStats> settings)
		{
			this.UIEngine = settings.UIEngine;
			this.InputProvider = this.UIEngine.InputProvider;
			this.Field = settings.Field;
			this.Player = settings.Player;
			this.HighScores = settings.HighScores;

			this.ActionProvider = settings.ActionProvider;
			this.GameOverChecker = settings.GameOverChecker;

			this.MoveableEntity = new MoveableField(this.Field, settings.Movement);
			this.ActionReceiver = new DefaultActionReceiver(this);
			this.AttachUIToEvents();
		}

		#region Events

		public event Action GameStart;

		public event Action GameEnd;

		public event Action GameExit;

		public event Action GameMovement;

		public event Action GameShowScore;

		public event Action GameIllegalMove;

		public event Action GameIllegalCommand;

		public event CustomEventHandler GameCustomEvent;

		#endregion Events

		#region Properties

		public virtual IDefaultUIEngine UIEngine
		{
			get
			{
				return this._uIEngine;
			}

			set
			{
				Validation.ThrowIfNull(value);
				this._uIEngine = value;
			}
		}

		public virtual IInputProvider InputProvider
		{
			get
			{
				return this._inputProvider;
			}

			set
			{
				Validation.ThrowIfNull(value);
				this._inputProvider = value;
			}
		}

		public virtual IField Field
		{
			get
			{
				return this._field;
			}

			set
			{
				Validation.ThrowIfNull(value);
				this._field = value;
			}
		}

		public virtual IPlayer Player
		{
			get
			{
				return this._player;
			}

			set
			{
				Validation.ThrowIfNull(value);
				this._player = value;
			}
		}

		public virtual IIntegerStats HighScores
		{
			get
			{
				return this._highScores;
			}

			set
			{
				Validation.ThrowIfNull(value);
				this._highScores = value;
			}
		}

		public virtual IMoveable MoveableEntity
		{
			get
			{
				return this._moveableEntity;
			}

			set
			{
				Validation.ThrowIfNull(value);
				this._moveableEntity = value;
			}
		}

		public virtual IGameOverChecker GameOverChecker
		{
			get
			{
				return this._gameOverChecker;
			}

			set
			{
				Validation.ThrowIfNull(value);
				this._gameOverChecker = value;
			}
		}

		protected virtual IActionProvider ActionProvider
		{
			get
			{
				return this._actionProvider;
			}

			set
			{
				Validation.ThrowIfNull(value);
				this._actionProvider = value;
			}
		}

		protected virtual IActionReceiver ActionReceiver
		{
			get
			{
				return this._actionReceiver;
			}

			set
			{
				Validation.ThrowIfNull(value);
				this._actionReceiver = value;
			}
		}

		#endregion Properties

		#region Methods

		public virtual void Start()
		{
			while (!this._gameExit)
			{
				this.OnGameStart();
				this.StartGame();

				bool isSolved = this.IsItGameOver();
				while (!this._gameExit && !isSolved)
				{
					this.OnGameMovement();

					var key = this.InputProvider.GetKeyInput();
					var action = this.ActionProvider.GetAction(key, this.ActionReceiver);
					action.Execute();

					isSolved = this.IsItGameOver();
				}

				if (isSolved)
				{
					this.OnGameEnd();

					var playerScore = new NameValue<int>(this.Player.Name, this.Player.Score);
					this.HighScores.Save(playerScore);
				}
			}
		}

		public virtual bool Move(Direction direction)
		{
			return this.MoveableEntity.Move(direction);
		}

		public virtual void Exit()
		{
			this.OnGameExit();
			this._gameExit = true;
		}

		public virtual void StartGame()
		{
			this.Player.Score = 0;
			this.Field.RandomizeField(this.UIEngine.Difficulty);
			this.FieldInvalidate();
		}

		public virtual void IllegalMove()
		{
			this.OnGameIllegalMove();
		}

		public virtual void IllegalCommand()
		{
			this.OnGameIllegalCommand();
		}

		public virtual void FieldInvalidate()
		{
			this.OnGameCustomEvent(new FieldInvalidateEvent(this.Field));
		}

		public virtual void ShowScore()
		{
			this.OnGameCustomEvent(new ShowScoreEvent(this.HighScores));
		}

		protected virtual bool IsItGameOver()
		{
			return this.GameOverChecker.IsItOver(this.Field);
		}

		protected virtual void AttachUIToEvents()
		{
			this.GameStart += this.UIEngine.OnGameStart;
			this.GameEnd += this.UIEngine.OnGameEnd;
			this.GameExit += this.UIEngine.OnGameExit;
			this.GameMovement += this.UIEngine.OnGameMovement;
			this.GameIllegalMove += this.UIEngine.OnGameIllegalMove;
			this.GameIllegalCommand += this.UIEngine.OnGameIllegalCommand;
			this.GameCustomEvent += this.UIEngine.OnGameCustomEvent;
		}

		#region Events

		private void OnGameStart()
		{
			if (this.GameStart != null)
			{
				this.GameStart();
			}
		}

		private void OnGameEnd()
		{
			if (this.GameEnd != null)
			{
				this.GameEnd();
			}
		}

		private void OnGameExit()
		{
			if (this.GameExit != null)
			{
				this.GameExit();
			}
		}

		private void OnGameMovement()
		{
			if (this.GameMovement != null)
			{
				this.GameMovement();
			}
		}

		private void OnGameShowScore()
		{
			if (this.GameShowScore != null)
			{
				this.GameShowScore();
			}
		}

		private void OnGameIllegalMove()
		{
			if (this.GameIllegalMove != null)
			{
				this.GameIllegalMove();
			}
		}

		private void OnGameIllegalCommand()
		{
			if (this.GameIllegalCommand != null)
			{
				this.GameIllegalCommand();
			}
		}

		private void OnGameCustomEvent(object eventObject)
		{
			if (this.GameCustomEvent != null)
			{
				this.GameCustomEvent(eventObject);
			}
		}

		#endregion Events

		#endregion Methods
	}
}