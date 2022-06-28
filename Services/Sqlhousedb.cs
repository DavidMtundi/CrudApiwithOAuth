using OOauthApi.Interfaces;
using OOauthApi.Models;

namespace OOauthApi.Services
{
    public class Sqlhousedb : IHouse
    {
        private Housemodelcontext housemodelcontext;
        /// <summary>
        /// constructor, that initializes the housemodelcontext
        /// </summary>
        /// <param name="_housemodelcontext"></param>
        public Sqlhousedb(Housemodelcontext _housemodelcontext)
        {
            housemodelcontext = _housemodelcontext;
        }
        /// <summary>
        /// creates a new house
        /// </summary>
        /// <param name="Housemodel"></param>
        /// <returns></returns>
        public Housemodel createHouse(Housemodel house)
        {
            housemodelcontext.Houses.Add(house);
            housemodelcontext.SaveChanges();
            return house;
        }
        /// <summary>
        /// Deletes a given house provided returns a bool
        /// </summary>
        /// <param name="Housemodel"></param>
        /// <returns></returns>

        public bool deleteHouse(Housemodel house)
        {
            var id = housemodelcontext.Houses.Find(house.Id);
            if (id != null)
            {
                housemodelcontext.Houses.Remove(id);
                housemodelcontext.SaveChanges();

                return true;

            }
            return false;
        }
        /// <summary>
        /// gets all the houses, retuns a list<Housemodels>
        /// </summary>
        /// <returns></returns>
        public List<Housemodel> getAllHouses()
        {
            return housemodelcontext.Houses.ToList();
        }
        /// <summary>
        /// gets a specific house with a given id, returns Housemodel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Housemodel getHouse(int id)
        {
            Housemodel house = housemodelcontext.Houses.Find(id);
            if (house != null)
            {
                return house;
            }
            return house;
        }
        /// <summary>
        /// updates the house provided, returns a Housemodel
        /// </summary>
        /// <param name="house"></param>
        /// <returns></returns>
        public Housemodel updateHouse(Housemodel house)
        {
            var id = housemodelcontext.Houses.Find(house.Id);
            if (id != null)
            {
                housemodelcontext.Houses.Update(house);
                housemodelcontext.SaveChanges();

            }
            return house;
        }
    }
}
