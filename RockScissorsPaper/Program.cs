﻿using RockScissorsPaper.Models;
using RockScissorsPaper.Utils.Generators;


class Program
{
    static void Main(string[] args)
    {
        (bool areArgsValid, List<string> errors) = GameMovesValidator.ValidateMoves(args);
        if (!areArgsValid)
        {
            errors.ForEach(Console.WriteLine);
            return;
        }

        byte[] hmacKey = KeyGenerator.GenerateKey();

        Game game = new Game(args, HMACGenerator.GenerateHMACSHA256);
        game.Start(hmacKey);
    }
}