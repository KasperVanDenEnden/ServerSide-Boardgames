using Domain;
using Domain.Many_To_Many;
using Domainservices.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Services
{
    public class GamenightService : IGamenightService
    {

        public Gamenight CreateFromModel(dynamic model,int hostId, List<Boardgame> boardgameList)
        {

            var address = CreateAddressFromModel(model);

            var gamenight = new Gamenight()
            {

                Name = model.Title,
                Description = model.Description,
                DateTime = model.Date + model.Time,
                IsPG18 = model.IsPG18,
                MaxParticipants = model.MaxParticipants,
                Address = address,
                HostId = hostId,
                Image = SetImage(model.SelectedBoardgameIds, boardgameList),
            };

            return CheckOnPG18Boardgames(gamenight, model.SelectedBoardgameIds, boardgameList);
        }

        public Gamenight CreateUpdatedGamenightFromModel(dynamic updatedModel,Gamenight gamenight, List<Boardgame> boardgameList)
        {

            gamenight.Name = updatedModel.Title;
            gamenight.Description = updatedModel.Description;
            gamenight.DateTime = updatedModel.Date + updatedModel.Time;
            gamenight.IsPG18 = updatedModel.IsPG18;
            gamenight.MaxParticipants = updatedModel.MaxParticipants;
            gamenight.Address.Street = updatedModel.Street;
            gamenight.Address.Housenumber = updatedModel.Housenumber;
            gamenight.Address.Postal = updatedModel.Postal;
            gamenight.Address.City = updatedModel.City;
            gamenight.Image = SetImage(updatedModel.SelectedBoardgameIds, boardgameList);

            return CheckOnPG18Boardgames(gamenight, updatedModel.SelectedBoardgameIds, boardgameList); ;
        }

        public byte[] SetImage(List<int> selectedBoardgameIds, List<Boardgame> boardgameList)
        {
            Random random = new Random();
            int randomId = selectedBoardgameIds[random.Next(selectedBoardgameIds.Count)];
            Boardgame randomBoardgame = boardgameList.FirstOrDefault(bg => bg.Id == randomId);
            return randomBoardgame.Image;
        }

        public Address CreateAddressFromModel(dynamic model)
        {
            return new Address()
            {
                Street = model.Street,
                City = model.City,
                Housenumber = model.Housenumber,
                Postal = model.Postal,
            };
        }

        public Gamenight CheckOnPG18Boardgames(Gamenight gamenight, List<int> selectedBoardgames, List<Boardgame> boardgameList)
        {

            foreach (int selectedBoardgameId in selectedBoardgames)
            {
                // Find the corresponding boardgame in boardgameList
                Boardgame selectedBoardgame = boardgameList.FirstOrDefault(bg => bg.Id == selectedBoardgameId);

                // Check if the boardgame exists and its IsPG18 value is true
                if (selectedBoardgame != null && selectedBoardgame.IsPG18)
                {
                    gamenight.IsPG18 = true;
                    break; // Exit the loop since the condition is satisfied
                }
            }

            return gamenight;
        }

        public bool EditOrDeleteAllowed(Gamenight gamenight)
        {
            if (gamenight.Participants.Count == 0)
            {
                return true;
            }
            return false;
        }

        public Participating CreateNewParticipatingClass(int gamenightId, int userId)
        {
            return new Participating { GamenightId = gamenightId, UserId = userId };
        }

        public Task<object> GamenightToViewModel(Gamenight gamenight)
        {
                object viewModel = new
                {
                    Id = gamenight.Id,
                    Title = gamenight.Name,
                    Description = gamenight.Description,
                    Date = new DateOnly(gamenight.DateTime.Year,gamenight.DateTime.Month,gamenight.DateTime.Day),
                    Time = new TimeOnly(gamenight.DateTime.Hour, gamenight.DateTime.Minute),
                    IsPG18 = gamenight.IsPG18,
                    MaxParticipants = gamenight.MaxParticipants,
                    Street = gamenight.Address.Street,
                    Housenumber = gamenight.Address.Housenumber,
                    City = gamenight.Address.City,
                    Postal = gamenight.Address.Postal,
                    SelectedBoardgameIds = gamenight.Boardgames?.Select(p => p.BoardgameId).ToList() ?? new List<int>()
                };

                return Task.FromResult(viewModel);

        }

      
    }
}
