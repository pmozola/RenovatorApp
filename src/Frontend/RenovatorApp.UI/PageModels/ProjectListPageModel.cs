#nullable disable
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RenovatorApp.UI.Data;
using RenovatorApp.UI.Models;
using RenovatorApp.UI.Services;

namespace RenovatorApp.UI.PageModels;

public partial class ProjectListPageModel : ObservableObject
{
    private readonly ProjectRepository _projectRepository;
    private readonly ShopListItemHttpService _shopListItemHttpService;

    [ObservableProperty] private List<Project> _projects = [];

    public ProjectListPageModel(ProjectRepository projectRepository, ShopListItemHttpService shopListItemHttpService)
    {
        _projectRepository = projectRepository;
        _shopListItemHttpService = shopListItemHttpService;
    }

    [RelayCommand]
    private async Task Appearing()
    {
        Projects = await _projectRepository.ListAsync();
        Projects = (await _shopListItemHttpService.Get()).Select(x => new Project{Name = x.Name, Description = x.Description}).ToList();
    }

    [RelayCommand]
    Task NavigateToProject(Project project)
        => Shell.Current.GoToAsync($"project?id={project.ID}");

    [RelayCommand]
    async Task AddProject()
    {
        await Shell.Current.GoToAsync($"project");
    }
}