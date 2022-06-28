using OOauthApi.Models;

namespace OOauthApi.Interfaces
{
    public interface IHouse
    {
        //create a new house
        Housemodel createHouse(Housemodel house);
        //update an existing house
        Housemodel updateHouse(Housemodel house);
        //delete an existing house
        bool deleteHouse(Housemodel house);
        //return all the houses exisitng
        List<Housemodel> getAllHouses();
        //get house by id
        Housemodel getHouse(int id);
    }
}
