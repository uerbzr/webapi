using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using webapi.Data.Services;
using webapi.Models;

namespace webapi.Endpoints
{
    public static class PeopleApi
    {
        public static void ConfigurePeopleApi(this WebApplication app)
        {
            app.MapGet("/people", GetUsers);
            app.MapGet("/people/{id}", GetUser);
            app.MapPost("/people", InsertUser);
            app.MapPut("/people", UpdateUser);
            app.MapDelete("/people", DeleteUser);
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
                return await Task.Run(() =>
                {
                    var person = service.GetAll().Where(x => x.Id == id).FirstOrDefault();
                    if (person == null) return Results.NotFound();
                    return Results.Ok(person);
                });

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
                if(service.Add(person)) return Results.Ok();
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
                return await Task.Run(() =>
                {
                    if(service.UpdateUser(person)) return Results.Ok();
                    return Results.NotFound();
                });

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
