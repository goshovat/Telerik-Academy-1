namespace ComputerSystem.Core
{
    public class Motherboard : IMotherboard
    {
        public Motherboard(Ram ram, VideoCard videoCard)
        {
            this.Ram = ram;
            this.VideoCard = videoCard;
        }

        public Ram Ram { get; set; }

        public VideoCard VideoCard { get; set; }

        public int LoadRamValue()
        {
            return Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            Ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            VideoCard.Draw(data);
        }
    }
}
