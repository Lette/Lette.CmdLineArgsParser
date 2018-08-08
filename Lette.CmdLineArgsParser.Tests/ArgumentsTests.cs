using Xunit;

namespace Lette.CmdLineArgsParser.Tests
{
    public class ArgumentsTests
    {
        [Fact]
        public void Invoking_key_argument_calls_action_with_input()
        {
            int effect;

            void Action(int i) => effect = i;

            var keyArgument = new KeyArgument<int>(null, Action);

            effect = 0;

            keyArgument.Invoke(1);

            Assert.Equal(1, effect);
        }
    }
}
