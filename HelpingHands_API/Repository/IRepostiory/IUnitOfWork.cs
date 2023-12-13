﻿
using HelpingHands_API.Models;
using HelpingHands_API.Repository.IRepostiory;
using System.Linq.Expressions;

namespace HelpingHands_API.Repository.IRepostiory
        //ICategoryRepository Category { get; }
        IAmenityRepository Amenity { get; }

        ISecondCategoryRepository SecondCategory { get; }
        IServiceRepository Service { get; }
        IThirdCategoryRepository ThirdCategory { get; }

        IApplicationUserRepository ApplicationUser { get; }
        IApplicationRoleRepository ApplicationRole { get; }
        IApplicationUserRoleRepository ApplicationUserRole { get; }
        IUserRepository User { get; }


        void Save();