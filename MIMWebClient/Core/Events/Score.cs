﻿namespace MIMWebClient.Core.Events
{
    using System.Text;
    using System.Web.Helpers;

    using Microsoft.ApplicationInsights.Extensibility.Implementation;

    using MIMWebClient.Core.Room;

    using MongoDB.Bson;

    using PlayerSetup;

    class Score
    {

        public static void ReturnScore(Player playerData)
        {
            string scoreTest = "Score:\r\n Name: " + playerData.Name + " Race: " + playerData.Race;

            var context = HubContext.getHubContext;
            context.Clients.Client(playerData.HubGuid).addNewMessageToPage(scoreTest);
        }

        public static void ReturnScoreUI(Player playerData)
        {
   
            var context = HubContext.getHubContext;
            context.Clients.Client(playerData.HubGuid).updateScore(playerData);
        }

        public static void UpdateUiPrompt(Player playerData)
        {

            var context = HubContext.getHubContext;
            context.Clients.Client(playerData.HubGuid).updateStat(playerData.HitPoints, playerData.MaxHitPoints, "hp");
            context.Clients.Client(playerData.HubGuid).updateStat(playerData.ManaPoints, playerData.MaxManaPoints, "mana");
            context.Clients.Client(playerData.HubGuid).updateStat(playerData.MovePoints, playerData.MaxMovePoints, "endurance");
            context.Clients.Client(playerData.HubGuid).updateStat(playerData.ExperienceToNextLevel, playerData.Experience, "tnl");
        }

        public static void UpdateUiInventory(Player playerData)
        {

            var context = HubContext.getHubContext;
            context.Clients.Client(playerData.HubGuid).updateInventory(playerData.Inventory);
       
        }


        public static void UpdateUiRoom(Player playerData, string room)
        {
            //var room = new Room.Room();
            //var currentRoom = p
            var context = HubContext.getHubContext;
            context.Clients.Client(playerData.HubGuid).updateRoom(playerData, room);
            //context.Clients.Client(playerData.HubGuid).updateRoom(playerData.Inventory);

        }
    }
}
