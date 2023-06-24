﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Interfaces.IRepositories
{
    public interface IGamenightRepository
    {
        // POST, PUT, DELETE
        public Task<Gamenight> AddGamenightAsync(Gamenight newGamenight);
        public Task<bool> UpdateGamenightAsync(Gamenight gamenight);
        public Task<bool> RemoveGamenightAsync(int gamenightId);


        // GETS: Overviews
        public Task<List<Gamenight>> GetGamenightsAsync();
        public Task<List<Gamenight>> GetGamenightsParticipatingAsync(int userId);
        public Task<List<Gamenight>> GetGamenightsHostingAsync(string username);


    }
}
