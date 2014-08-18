namespace Computers.Components.Factories
{
    using Computers.Components;

    internal static class VideoCardFactory
    {
        internal static VideoCard CreateVideoCard(bool isMonochrome)
        {
            VideoCard videoCard = new VideoCard();

            if (isMonochrome)
            {
                videoCard.IsMonochrome = true;
            }
            else
            {
                videoCard.IsMonochrome = false;
            }

            return videoCard;
        }
    }
}
