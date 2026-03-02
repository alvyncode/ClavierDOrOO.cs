namespace ViewModels.Service;

public class NavigationManager
{
    public static event Action VueAChangee;

    private static object _vueCourante;

    public static object VueCourante
    {
        get => _vueCourante;
        set
        {
            _vueCourante = value;
            VueAChangee?.Invoke(); 
        }
    }


}
