﻿using Domain;
using Domain.Many_To_Many;
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
        public Task<List<Participating>> GetGamenightsParticipatingAsync(string username);
        public Task<List<Gamenight>> GetGamenightsHostingAsync(string username);


    }
}