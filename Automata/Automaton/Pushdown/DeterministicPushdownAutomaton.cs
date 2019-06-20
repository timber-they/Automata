using System;
using System.Collections.Generic;
using DeterministicAutomata.Automaton;
using DeterministicAutomata.Types.General;
using DeterministicAutomata.Types.Pushdown;
using DeterministicAutomata.Types.Pushdown.Deterministic;

namespace Automata.Automaton.Pushdown
{
    public class DeterministicPushdownAutomaton : BasicAutomaton
    {
        public DeterministicPushdownAutomaton(HashSet<State> states, Alphabet inputAlphabet, State initialState, HashSet<State> acceptStates, DeterministicPushdownTransitionFunction transitionFunction, Stack stack)
            : base(states, inputAlphabet, initialState, acceptStates)
        {
            TransitionFunction = transitionFunction;
            Stack = stack;
        }

        public DeterministicPushdownTransitionFunction TransitionFunction { get; }
        public Stack Stack { get; }

        public override bool Accepts(Word word)
        {
            var currentState = InitialState;
            var currentSymbol = Stack.Pop();

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}