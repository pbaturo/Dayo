using Dayo;
using Xunit;

namespace Dayo.Tests
{
    public class MainWindowViewModelTests
    {
        [Fact]
        public void AddCheckBox_InsertsSymbolAtCaretIndex()
        {
            var viewModel = new MainWindowViewModel(new Store());
            viewModel.Content = "abcd";
            viewModel.CaretIndex = 2;

            viewModel.AddCheckBox(viewModel.Content);

            Assert.Equal("ab\u2610cd", viewModel.Content);
        }
    }
}

