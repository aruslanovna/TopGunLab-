
using Domain;

namespace BLLayer.RefereeService
{
    public interface IReferee
    {     
        void addToFavouriteTeam(Referee referee);
        Referee GetRefereeById(int referee);
    }

}