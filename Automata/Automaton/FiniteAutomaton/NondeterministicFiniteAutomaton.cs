using System.Collections.Generic;
using System.Linq;
using DeterministicAutomata.Types.Finite.Nondeterministic;
using DeterministicAutomata.Types.General;

namespace DeterministicAutomata.Automaton.FiniteAutomaton
{
    public class NondeterministicFiniteAutomaton : BasicAutomaton
    {
        public NondeterministicFiniteAutomaton(HashSet<State> states, Alphabet inputAlphabet, NondeterministicFiniteTransitionFunction transitionFunction, State initialState, HashSet<State> acceptStates)
            : base(states, inputAlphabet, initialState, acceptStates)
            => TransitionFunction = transitionFunction;

        public NondeterministicFiniteTransitionFunction TransitionFunction { get; }

        public override bool Accepts(Word word)
        {
            var currentStates = new HashSet<State> {InitialState};
            foreach (var inputSymbol in word.InputSymbols)
            {
                var newStates = new HashSet<State>();
                foreach (var state in currentStates)
                {
                    var resultStates = TransitionFunction.GetNextStates(state, inputSymbol);
                    foreach (var resultState in resultStates)
                        newStates.Add(resultState);
                }

                currentStates = newStates;
            }

            return AcceptStates.Any(accept => currentStates.Any(accept.Equals));
        }

        public override bool Equals(object obj)
            => obj is NondeterministicFiniteAutomaton finiteAutomaton && Equals(finiteAutomaton);

        protected bool Equals(NondeterministicFiniteAutomaton other)
            => Equals(TransitionFunction, other.TransitionFunction) && base.Equals(other);

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = States != null ? States.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (InputAlphabet != null ? InputAlphabet.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TransitionFunction != null ? TransitionFunction.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (InitialState != null ? InitialState.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AcceptStates != null ? AcceptStates.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}