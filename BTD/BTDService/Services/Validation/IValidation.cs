﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTDService.Services.Validation
{
    public interface IValidation
    {
        Task<ValidationType> ValidationUserByPassword(string login, string password);
    }
}