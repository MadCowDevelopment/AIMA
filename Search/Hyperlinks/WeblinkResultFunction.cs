using Search.Framework;

namespace Search.Hyperlinks
{
    public class WeblinkResultFunction : ResultFunction<WeblinkState, WeblinkAction>
    {
        public override WeblinkState Result(WeblinkState state, WeblinkAction action)
        {
            return new WeblinkState(action.Url);
        }
    }
}
