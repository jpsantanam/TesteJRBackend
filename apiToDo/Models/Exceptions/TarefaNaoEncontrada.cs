﻿using System;

namespace apiToDo.Models.Exceptions
{
    public class TarefaNaoEncontrada : Exception
    {
        public TarefaNaoEncontrada()
        {
        }

        public TarefaNaoEncontrada(string message)
            : base(message)
        {
        }

        public TarefaNaoEncontrada(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}