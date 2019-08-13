using System;
using System.Collections.Generic;
using System.Linq;
using Archysoft.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Archysoft.Data
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;


        public DatabaseInitializer(DataContext dataContext, UserManager<User> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public void Initialize()
        {
            _dataContext.Database.Migrate();
            if (_dataContext.Users.Any()) return;

            byte[] imageData = (Resource.img_avatar2);

            var skills = new List<Skill>
            {
                new Skill {Name = "java"},
                new Skill {Name = "C#"}
            };
            foreach (var skill in skills)
            {
                _dataContext.Skills.Add(skill);

            }
            var languages = new List<Language>
            {
                new Language {Name = "English"},
                new Language {Name = "Russian"}
            };
            foreach (var lang in languages)
            {
                _dataContext.Languages.Add(lang);
            }

            var citiesU = new List<City>
                {new City {Name = "Odessa"}, new City {Name = "Lviv"}, new City {Name = "Kyiv"}};
            _dataContext.AddRange(citiesU);
            var citiesN = new List<City> { new City { Name = "Okland" } };
            _dataContext.AddRange(citiesN);
            var citiesUsa = new List<City> { new City { Name = "New York" }, new City { Name = "Boston" } };
            _dataContext.AddRange(citiesUsa);

            var countries = new List<Country>
            {
                new Country {Name = "Ukraine", Cities=citiesU},
                new Country {Name = "New Zeland", Cities=citiesN},
                new Country {Name = "USA", Cities=citiesUsa}
            };
            _dataContext.AddRange(countries);


            Description description = new Description
            {
                Title = "Expert WordPress, PHP Developer and APIs Integration",
                Text = @"I am Computer Engineer having 6+ years of website development, design and database experience. I have done projects for various clients under various domains like car dealers, real estate, job boards, forex , eCommerce etc.

I have hands on experience in PHP, Wordpress, Joomla, Magento, Mysql, Oracle, ASP.NET, HTML, CSS, Photoshop.

Experienced in Wordpress/ Joomla/ Magento sites, development, configuration, optimization, migration, custom theme development. Working with various plugins and widgets, customization according to client requirements."
            };

            var users = new List<User>
            {
                new User {
                    UserName = "admin",
                    Email = "admin@d1.archysoft.com",
                    PhoneNumber="123456789",
                    EmailConfirmed = true,
                    Profile = new UserProfile {
                        FirstName = "John",
                        LastName = "Doe",
                        BirthDate = DateTime.Now.AddDays(-1),
                        Photo = imageData,
                        Description = description,
                        Skype="AdminSkype",
                        City=countries.ToList()[0].Cities.ToList()[0]
                    }
                },
                new User {
                    UserName = "jane.doe",
                    Email = "jane.doe@d1.archysoft.com",
                    PhoneNumber="123456889",
                    EmailConfirmed = true,
                    Profile = new UserProfile {
                        FirstName = "Jane",
                        LastName = "Doe",
                        BirthDate = DateTime.Now.AddDays(-2),
                        Photo = imageData,
                        Description = description,
                        Skype="AdminSky",
                        City=countries.ToList()[0].Cities.ToList()[1]

                    }
                },
                new User {
                    UserName = "john.smith",
                    Email = "john.smith@d1.archysoft.com",
                    PhoneNumber="1234533389",
                    EmailConfirmed = true,
                    Profile = new UserProfile {
                        FirstName = "John",
                        LastName = "Smith",
                        BirthDate = DateTime.Now.AddDays(-3),
                        Photo = imageData,
                        Description = description,
                        Skype="AdmSkype",
                        City=countries.ToList()[0].Cities.ToList()[2]

                    }
                },
                new User {
                    UserName = "admin1",
                    Email = "admin@d11.archysoft.com",
                    PhoneNumber="123236789",
                    EmailConfirmed = true,
                    Profile = new UserProfile {
                        FirstName = "John1",
                        LastName = "Doe1",
                        BirthDate = DateTime.Now.AddDays(-1),
                        Photo = imageData,
                        Description = description,
                        Skype="Ape",
                        City=countries.ToList()[1].Cities.ToList()[0]

                    }
                },
                new User {
                    UserName = "jane.doe1",
                    Email = "jane.doe1@d1.archysoft.com",
                    PhoneNumber="12222456789",
                    EmailConfirmed = true,
                    Profile = new UserProfile {
                        FirstName = "Jane1",
                        LastName = "Doe1",
                        BirthDate = DateTime.Now.AddDays(-2),
                        Photo = imageData,
                        Description = description,
                        Skype="AdmSky",
                        City=countries.ToList()[2].Cities.ToList()[0]

                    }
                },
                new User {
                    UserName = "john.smith1",
                    Email = "john.smith1@d1.archysoft.com",
                    PhoneNumber="1234434789",
                    EmailConfirmed = true,
                    Profile = new UserProfile {
                        FirstName = "John1",
                        LastName = "Smith1",
                        BirthDate = DateTime.Now.AddDays(-3),
                        Photo = imageData,
                        Description = description,
                        Skype="Ay",
                        City=countries.ToList()[2].Cities.ToList()[0]

                    }
                }
            };

            int i = 0;
            foreach (var user in users)
            {
                var result = _userManager.CreateAsync(user, "admin").Result;
                if (!result.Succeeded)
                {
                    throw new InvalidOperationException();
                }

                var profile = new UserProfile
                {
                    UserId = user.Id,
                    FirstName = user.Profile.FirstName,
                    LastName = user.Profile.LastName,
                    BirthDate = user.Profile.BirthDate,
                    Photo = user.Profile.Photo,
                    Skype = user.Profile.Skype,                   
                    City=user.Profile.City,

                    Description = new Description
                    {
                        Title = user.Profile.Description.Title,
                        Text = user.Profile.Description.Text
                    },
                    Educations = new List<Education>
                    {
                        {new Education {School="Software Development: IT STEP Academy", Degree="Bachelor of Engineering (B.Eng.)", YearAttendedFrom=2016, YearAttendedTo=2019}},
                        {new Education{School="Odessa National Maritime College", Degree="Bachelor of Engineering (B.Eng.)",YearAttendedFrom=2001, YearAttendedTo=2007} }
                    },
                    Experiences = new List<Experience>
                    {
                        new Experience
                            {
                                Position ="Senior Software Engineer at Emsisoft (Upwork)",
                                Description =@"This was my first and biggest project on Upwork. I had to review existing ASP.NET WebForms applications and rewrite them using modern technologies such as ASP.NET Web API and AngularJS (later I’ve used ASP.NET Core and Angular). It was a challenging job as I had to migrate existing applications without any errors! Finally we’ve created a very responsive and highly optimized SaaS application and a lot of small internal applications for the backoffice.",
                                BeginDate=new DateTime(2016, 4,1),
                                EndDate=new DateTime(2018,12,1)
                            },
                        new Experience
                        {
                            Position="Senior Software Engineer at Diatom (Latvia)",
                            Description=@"This was my first remote job, so it was an approbation for my self-organization and
                            discipline. I was working on two not very big projects, based on the MS SQL +
                            Entity Framework, Web API and Angular JS also we had automated tests using
                            Selenium.One of them I built from scratch!It was interesting and challenging
                            work!",
                            BeginDate=new DateTime(2014, 9,1),
                            EndDate=new DateTime(2015,12,1)
                        }
                    },
                    UserProfileSkills =
                        i % 2 == 0
                        ? new List<UserProfileSkill> { new UserProfileSkill { Skill = skills[0], UserProfile = users[i].Profile } }
                        : new List<UserProfileSkill> { new UserProfileSkill { Skill = skills[1], UserProfile = users[i].Profile } },
                    UserProfileLanguages = new List<UserProfileLanguage>
                    {
                        new UserProfileLanguage { Language = languages[0], UserProfile = users[i].Profile },
                        new UserProfileLanguage { Language = languages[1], UserProfile = users[i].Profile }
                    }
                };



                _dataContext.Descriptions.Add(profile.Description);
                _dataContext.UserProfiles.Add(profile);
                ++i;
            }

            _dataContext.SaveChanges();
        }
    }
}
