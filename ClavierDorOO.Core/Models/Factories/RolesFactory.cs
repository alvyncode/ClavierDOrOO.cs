using Models.Roles;
namespace Models.Factories;
public static class RolesFactory
{
    public static Role ChoisirRole(String StrRole)
    {
        switch (StrRole)
        {
            case "Développeur Front":
                return new DeveloppeurFront();
            case "Développeur Back":
                return new DeveloppeurBack();
            case "Développeur Mobile":
                return new DeveloppeurMobile();
            default:
                return new DeveloppeurFront();
        
        }
    }

}
