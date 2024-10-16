using Module05Exercise01.Services;
using Module05Exercise01.ViewModel;

namespace Module05Exercise01.View;

public partial class ViewEmployeee : ContentPage
{
	public ViewEmployeee()
	{
		InitializeComponent();

        var employeeViewModel = new EmployeeViewModel();
        BindingContext = employeeViewModel;
    }
}