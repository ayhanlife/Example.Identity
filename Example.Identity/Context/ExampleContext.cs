﻿using Example.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;using Microsoft.EntityFrameworkCore;namespace Example.Identity.Context{    public class ExampleContext : IdentityDbContext<AppUser,AppRole,int>    {        public ExampleContext(DbContextOptions<ExampleContext> options):base(options)        {                    }    }}