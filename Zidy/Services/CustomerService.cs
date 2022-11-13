using Newtonsoft.Json;
using RestSharp;
using Zidy.Domain.Dto;
using Zidy.Domain.Interfaces;

namespace Zidy.Services
{
    public class CustomerService : IServiceCustomer
    {
        RestClient client = new("https://run.mocky.io/v3/8cc1b858-2e3e-4249-a025-c0c52053d618");

        public async Task<List<User>> GetUsers()
        {
            CustomerDto customer = await getCustomer();
            List<User> users = getValidUsers(customer);

            return users;
        }

        public async Task<List<User>> GetUsersBySector()
        {
            CustomerDto customer = await getCustomer();
            List<User> users = getValidUsers(customer);
            List<User> usersBySector = new();

            foreach (var item in users)
            {
                for (int i = 0; i < customer.Sectors.GetLength(0); i++)
                {
                    if (usersBySector.Contains(item))
                        break;

                    for (int j = 0; j < customer.Sectors[i].GetLength(0); j++)
                    {
                        if (customer.Sectors[i][j] == (long?) item.Id)
                        {
                            usersBySector.Add(item);
                            break;
                        }
                    }
                }
            }


            return usersBySector;
        }

        public async Task<bool> CheckSectorDiagonal()
        {
            CustomerDto customerDto = await getCustomer();
            long?[][] sectors = customerDto.Sectors;
            //long?[][] sectors = new long?[3][] { new long?[] { 1, 2, 3 }, new long?[] { 4, 5, 6 }, new long?[] { 7, 8, 9 } };
            long? rightDiagonal = 0;
            long? leftDiagonal = 0;

            for (int i = 0; i < sectors.GetLength(0); i++)
            {
                for (int j = 0; j < sectors[i].GetLength(0); j++)
                {
                    //rightDiagonal
                    if (i == j)
                    {
                        rightDiagonal += sectors[i][j];
                    }

                    //leftDiagonal
                    if (i == 0 && j == sectors[i].GetLength(0)-1)
                    {
                        leftDiagonal += sectors[i][j];
                    }
                    if (i == sectors.GetLength(0)-1 && j == 0)
                    {
                        leftDiagonal += sectors[i][j];
                    }
                    if (i == j && i != 0 && i != sectors.GetLength(0) - 1)
                    {
                        leftDiagonal += sectors[i][j];
                    }
                }
            }
            return leftDiagonal == rightDiagonal;
        }

        public async Task<User> GetUserById(long id)
        {
            CustomerDto customer = await getCustomer();
            List<User> users = getValidUsers(customer);

            User user = users.Where(x => (long?)x.Id == id).FirstOrDefault();

            return user;
        }

        private async Task<CustomerDto> getCustomer()
        {
            RestRequest request = new RestRequest("", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<CustomerDto>(response.Content);
        }

        private List<User> getValidUsers(CustomerDto customer)
        {
            List<User> newUsers = new();

            foreach (var item in customer.Data.Users)
            {
                if (item.Id == null)
                    continue;

                if (item.Id.GetType() == typeof(string))
                    continue;

                item.FullName = item.FirstName + " " + item.LastName;
                newUsers.Add(item);
            }

            return newUsers;
        }
        
    }
}
