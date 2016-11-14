namespace SimpleLayout.Layout.Standard
{
    /// <summary>
    /// Standard layout that has no effect.
    /// Elements can be manually positioned using Offset and size.
    /// </summary>
    public class PassiveLayout : ILayout
    {
        public void Reset(ILayoutElement container)
        {
        }

        public void Process(ILayoutElement layoutElement)
        {
        }
    }
}
