// using GymHelperAPI.Models;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
//
// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<UsersDB>(options =>
// {
//     options.UseSqlServer("SqlServer");
// });
//
// builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<UsersDB>(options =>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
// });
//
// var app = builder.Build();
//
//
// if (app.Environment.IsDevelopment())
// {
//     using var scope = app.Services.CreateScope();
//     var db = scope.ServiceProvider.GetRequiredService<UsersDB>();
//     db.Database.EnsureCreated();
// }
//
// app.MapGet("/Users", async (UsersDB db) => await db.Users.ToListAsync());
// app.MapGet("/Users/{id}", async (int id, UsersDB db) =>
//     await db.Users.FirstOrDefaultAsync(p => p.Id == id) is User user
// ? Results.Ok(user)
// : Results.NotFound());
// app.MapPost("/users", (User user, UsersDB db) => db.Users.AddAsync(user));
// // app.MapPut("/users", (User user) =>
// // {
// //     var index = users.FindIndex(p => p.Id == user.Id);
// //     if (index < 0)
// //     {
// //         throw new Exception("Not found");
// //     }
// //     users[index] = user;
// // });
// // app.MapDelete("/Users/{id}", (int id) =>
// // {
// //     var index = users.FindIndex(p => p.Id == id);
// //     if (index < 0)
// //     {
// //         throw new Exception("Not found");
// //     }
// //
// //     users.RemoveAt(index);
// // });
//
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
// app.UseHttpsRedirection();
//
// app.UseAuthorization();
//
// app.MapControllers();
// app.Run();

Console.WriteLine();