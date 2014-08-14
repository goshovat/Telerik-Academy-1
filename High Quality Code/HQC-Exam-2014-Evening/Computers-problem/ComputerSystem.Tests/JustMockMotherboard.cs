namespace ComputerSystem.Tests
{
    using ComputerSystem.Core;
    using Telerik.JustMock;

    public class JustMockMotherboard : MotherboardMoq, IMotherboardMoq
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.MotherboardData = Mock.Create<IMotherboard>();

            Mock.Arrange(() => this.MotherboardData.DrawOnVideoCard(Arg.AnyString));
            Mock.Arrange(() => this.MotherboardData.SaveRamValue(Arg.AnyInt));
            Mock.Arrange(() => this.MotherboardData.LoadRamValue()).Returns(10);
        }
    }
}
