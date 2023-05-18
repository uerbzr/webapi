using Microsoft.AspNetCore.Builder;
using webapi.Data.Services;
using webapi.Models;

namespace webapi.Endpoints
{
    public static class StaffApi
    {
        public static void ConfigureStaffApi(this WebApplication app)
        {
            app.MapGet("/staff", GetUsers);
            app.MapGet("/staff/{id}", GetUser);
            app.MapPost("/staff", InsertUser);
            app.MapPut("/staff", UpdateUser);
            app.MapDelete("/staff", DeleteUser);
        }
        private static async Task<IResult> GetUsers(IPersonDataService service)
        {
            try
            {
                return Results.Ok(service.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetUser(int id, IPersonDataService service)
        {
            try
            {
                var person = service.GetAll().Where(x => x.Id == id).FirstOrDefault();
                if (person == null) return Results.NotFound();
                return Results.Ok(person);

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> InsertUser(Person person, IPersonDataService service)
        {
            try
            {
                if (service.Add(person)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> UpdateUser(Person person, IPersonDataService service)
        {
            try
            {
                if (service.UpdateUser(person)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteUser(int id, IPersonDataService service)
        {
            try
            {
                if (service.DeleteUser(id)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}
