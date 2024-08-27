namespace heidischwartz_c969
{
    public class WeekDayChangedEventArgs
    {
        public int weekDayIndex { get; private set; }

        public WeekDayChangedEventArgs(int weekDayIndex)
        {
            this.weekDayIndex = weekDayIndex;
        }
    }
}