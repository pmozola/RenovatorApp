using CommunityToolkit.Mvvm.Input;
using RenovatorApp.UI.Models;

namespace RenovatorApp.UI.PageModels;

public interface IProjectTaskPageModel
{
    IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
    bool IsBusy { get; }
}