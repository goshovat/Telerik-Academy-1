// CourseWork.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <algorithm>

using namespace std;

class Winner;
class Menu;

class Constituency
{
	private:
		vector<int> givenVotes;
		vector<string> parties;
	protected:
		char* name;
		int voters;
		int partyNumbers;
	public:
		Constituency(char* n, int v, int pn, vector<int> g, vector<string> par);
		Constituency(char* n, int v, vector<int> g, vector<string> par);
		Constituency(char* n, int v, int pn);
		static void SaveConstituencies(vector<Constituency>& contituencies, string fileName);
		static vector<Constituency> LoadConstituencies(string fileName);
		static vector<Winner> FindWinners(vector<Constituency>& contituencies);
		static void PrintConstituencies(vector<Constituency>& contituencies);
		string getName() const
		{
			return name;
		}
};

class Winner : public Constituency
{
private:
	int winnerVotes;
	string winnerParty;

public:
	Winner(char* n, int v, int pn, int wv, string wp);
	~Winner(){}
	static void PrintWinnerConstituenciesOfGivenParty(vector<Winner>& contituencies, string party);
	static void SaveWinners(vector<Winner>& contituencies, string fileName);
	static void PrintRunoff(vector<Winner>& contituencies);
};

class Menu
{
public:
	static vector<Constituency> Initialization()
	{
		vector<Constituency> constituencies;

		vector<int> votesBlg;
		votesBlg.push_back(2425);
		votesBlg.push_back(12532);
		votesBlg.push_back(15236);
		votesBlg.push_back(1872);
		votesBlg.push_back(7653);

		vector<string> parties;
		parties.push_back("AAA");
		parties.push_back("CCC");
		parties.push_back("DDD");
		parties.push_back("ZZZ");
		parties.push_back("KKK");

		constituencies.push_back(Constituency("Blagoevgrad", 39718, votesBlg, parties));

		vector<int> votesSofia;
		votesSofia.push_back(55421);
		votesSofia.push_back(2000);
		votesSofia.push_back(30521);
		votesSofia.push_back(10212);
		votesSofia.push_back(11113);
		constituencies.push_back(Constituency("Sofia", 109267, votesSofia, parties));

		vector<int> votesVarna;
		votesVarna.push_back(1113);
		votesVarna.push_back(1231);
		votesVarna.push_back(7654);
		votesVarna.push_back(65421);
		votesVarna.push_back(1222);
		constituencies.push_back(Constituency("Varna", 75410, votesVarna, parties));

		vector<int> votesBurgas;
		votesBurgas.push_back(3012);
		votesBurgas.push_back(400);
		votesBurgas.push_back(0);
		votesBurgas.push_back(8132);
		votesBurgas.push_back(781);
		constituencies.push_back(Constituency("Burgas", 12325, votesBurgas, parties));

		vector<int> votesPlovdiv;
		votesPlovdiv.push_back(5412);
		votesPlovdiv.push_back(20321);
		votesPlovdiv.push_back(156);
		votesPlovdiv.push_back(9113);
		votesPlovdiv.push_back(201);
		constituencies.push_back(Constituency("Plovdiv", 35203, votesPlovdiv, parties));

		vector<int> votesVelikoTurnovo;
		votesVelikoTurnovo.push_back(256);
		votesVelikoTurnovo.push_back(1113);
		votesVelikoTurnovo.push_back(1024);
		votesVelikoTurnovo.push_back(2048);
		votesVelikoTurnovo.push_back(512);
		constituencies.push_back(Constituency("Veliko Turnovo", 4953, votesVelikoTurnovo, parties));

		return constituencies;
	}

	static void ShowMenu()
	{
		cout << "Menu:" << endl;
		cout << "--------------------------" << endl;
		cout << "1. Show results" << endl;
		cout << "2. Save results to a file" << endl;
		cout << "3. Load results from a file" << endl;
		cout << "4. Print winner constituencies of given party" << endl;
		cout << "5. Save constituencies, which have winners to a file" << endl;
		cout << "6. Print constituencies, where are going to have runoff" << endl;
		cout << "0. Exit" << endl;
		cout << "--------------------------" << endl << endl;
	}
};

Constituency::Constituency(char* n, int v, vector<int> g, vector<string> par)
{
	if (g.size() != par.size())
	{
		throw new invalid_argument("The number of parties is not equal to the number of voted parties!");
	}

	name = n;
	voters = v;
	partyNumbers = g.size();
	givenVotes = g;
	parties = par;
}

Constituency::Constituency(char* n, int v, int pn, vector<int> g, vector<string> par)
{
	if (g.size() != par.size())
	{
		throw new invalid_argument("The number of parties is not equal to the number of voted parties!");
	}
	name = n;
	voters = v;
	partyNumbers = pn;
	givenVotes = g;
	parties = par;
}

Constituency::Constituency(char* n, int v, int pn)
{
	name = n;
	voters = v;
	partyNumbers = pn;
}

Winner::Winner(char* n, int v, int pn, int wv, string wp) : Constituency(n, v, pn)
{
	winnerVotes = wv;
	winnerParty = wp;
}

void Constituency::SaveConstituencies(vector<Constituency>& contituencies, string fileName)
{
	// open a file in write mode.
	ofstream outfile;
	outfile.open(fileName);


	if (outfile.is_open())
	{
		for (int i = 0; i < contituencies.size(); i++)
		{
			outfile << contituencies[i].name << endl;
			outfile<< contituencies[i].voters << endl;
			outfile<< contituencies[i].partyNumbers << endl;

			for (int j = 0; j < contituencies[i].partyNumbers; j++)
			{
				outfile<< contituencies[i].parties[j] << endl;
				outfile<< contituencies[i].givenVotes[j] << endl;
			}
			outfile << "END" << endl;
		}

		outfile.close(); // Close the file
		cout << "The list was successfully saved!" << endl << endl;
	}
	else
	{
		cout << "Unable to open file";
	}
}


vector<Constituency> Constituency::LoadConstituencies(string fileName)
{
	vector<Constituency> constituencies;

	string line;
	ifstream myfile (fileName);
	if (myfile.is_open())
	{

		char* name = "";
		int voters;
		int partiesNumber;
		vector<int> votes;
		vector<string> parties;

		int indexLine = 1;
		while (getline(myfile, line))
		{
			switch (indexLine)
			{
			case 1:
				name = new char[line.size() + 1];
				strcpy_s(name, line.length() + 1, line.c_str());
				indexLine++;
				break;
			case 2:
				voters = atoi(line.c_str());
				indexLine++;
				break;
			case 3:
				partiesNumber = atoi(line.c_str());
				indexLine++;
				break;
			case 4:
				for (int i = 0; i < partiesNumber; i++)
				{
					parties.push_back(line);
					getline(myfile, line);
					votes.push_back(atoi(line.c_str()));
					getline(myfile, line);
				}

				if (line == "END")
				{
					indexLine = 1;
					constituencies.push_back(Constituency(name, voters, partiesNumber, votes, parties));

					votes.erase(votes.begin(), votes.end());
					parties.erase(parties.begin(), parties.end());
				}
			}
		}

		myfile.close();
	}
	else
	{
		cout << "Unable to open file " << fileName << "!" << endl << endl;
		constituencies = Menu::Initialization();
	}

	return constituencies;
}

vector<Winner> Constituency::FindWinners(vector<Constituency>& contituencies)
{
	vector<Winner> winners;
	for (int i = 0; i < contituencies.size(); i++)
	{
		int max = 0;
		int index = 0;

		for (int j = 0; j < contituencies[i].partyNumbers; j++)
		{
			if (contituencies[i].givenVotes[j] > max)
			{
				max = contituencies[i].givenVotes[j];
				index = j;
			}
		}

		string party;
		int givenVote;

		if (max >= contituencies[i].voters / 2)
		{
			party = contituencies[i].parties[index];
			givenVote = contituencies[i].givenVotes[index];
		}
		else
		{
			party = "No winner";
			givenVote = 0;
		}

		winners.push_back(Winner(contituencies[i].name, contituencies[i].voters, contituencies[i].partyNumbers, givenVote, party));
	}

	return winners;
}

void Constituency::PrintConstituencies(vector<Constituency>& contituencies)
{
	for (int i = 0; i < contituencies.size(); i++)
	{
		cout << "Name : " << contituencies[i].name << endl;
		cout << "Number of voters : " << contituencies[i].voters << endl;
		cout << "Number of parties : " << contituencies[i].partyNumbers << endl;

		for (int j = 0; j < contituencies[i].parties.size(); j++)
		{
			cout << "Party name : " << contituencies[i].parties[j] << endl;
			cout << "Recieve votes : " << contituencies[i].givenVotes[j] << endl;
		}
		cout << endl;
	}
}

void Winner::PrintWinnerConstituenciesOfGivenParty(vector<Winner>& contituencies, string party)
{
	bool hasConstituency = false;
	for (int i = 0; i < contituencies.size(); i++)
	{
		if (contituencies[i].winnerParty == party)
		{
			hasConstituency = true;
			cout << "Name : " << contituencies[i].name << endl;
			cout << "Number of voters : " << contituencies[i].voters << endl;
			cout << "Number of parties : " << contituencies[i].partyNumbers << endl;
			cout << "Party name : " << contituencies[i].winnerParty << endl;
			cout << "Recieve votes : " << contituencies[i].winnerVotes << endl << endl;
		}
	}

	if (!hasConstituency)
	{
		cout << "Party " << party << " has no winner constituency!" << endl;
	}
}

void Winner::SaveWinners(vector<Winner>& contituencies, string fileName)
{
	ofstream outfile;
	outfile.open(fileName);

	if (outfile.is_open())
	{
		for (int i = 0; i < contituencies.size(); i++)
		{
			outfile << contituencies[i].name << " " << contituencies[i].winnerParty << endl;
		}

		outfile.close();
		cout << "The winners was successfully saved in the file " << fileName << endl << endl;
	}
	else
	{
		cout << "Unable to open file";
	}
}

void Winner::PrintRunoff(vector<Winner>& contituencies)
{
	bool hasConstituency = false;
	for (int i = 0; i < contituencies.size(); i++)
	{
		if (contituencies[i].winnerParty == "No winner")
		{
			hasConstituency = true;
			cout << contituencies[i].name << endl;
		}
	}

	if (!hasConstituency)
	{
		cout << "All constituencies have winners";
	}
}

// Use to sort elements
bool compare_by_name(const Winner& c1, const Winner& c2) {
	return c1.getName() < c2.getName();
}


int main()
{
	vector<Constituency> constituencies = Menu::Initialization();
	vector<Winner> winners = Constituency::FindWinners(constituencies);
	sort(winners.begin(), winners.end(), compare_by_name);

	int choice = 0;

	do
	{
		Menu::ShowMenu();
		cout << "Enter your choice: ";
		cin >> choice;

		string filename;
		string party;

		switch (choice)
		{
			case 1:
				cout << "The result from the votes:" << endl;
				cout << "--------------------------" << endl;

				Constituency::PrintConstituencies(constituencies);

				cout << "--------------------------" << endl;
				break;
			case 2:
				// Exercise 1
				cout << "\nEnter a name of the file, where the list will be saved : ";
				cin >> filename;
				filename += ".txt";

				Constituency::SaveConstituencies(constituencies, filename);
				break;
			case 3:
				cout << "\nEnter a name of the file, where the list was saved : ";
				cin >> filename;
				filename += ".txt";
				constituencies = Constituency::LoadConstituencies(filename);
				break;
			case 4:
				// Exercise 2
				cout << "\nEnter the name of the party, which you want to check : ";
				cin >> party;

				cout << "The result from the check:" << endl;
				cout << "--------------------------" << endl;

				Winner::PrintWinnerConstituenciesOfGivenParty(winners, party);

				cout << "--------------------------" << endl;
				break;
			case 5:
				// Exercise 3
				cout << "\nEnter a name of the file : ";
				cin >> filename;
				filename += ".txt";

				Winner::SaveWinners(winners, filename);
				break;
			case 6:
				// Exercise 4
				cout << "The constituencies with no winner:" << endl;
				cout << "--------------------------" << endl;

				Winner::PrintRunoff(winners);

				cout << "--------------------------" << endl;
				break;
			case 0:
				return 0;
			default:
				cout << "You entered a wrong choice " << choice << "!" << endl << endl;
				break;
		}

		cout << "Press enter to continue";
		_getch();
		system("CLS");
	} while (choice != 0);
}