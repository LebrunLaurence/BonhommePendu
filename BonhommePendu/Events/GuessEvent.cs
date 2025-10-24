using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
            Events.Add(new GuessedLetterEvent(gameData, letter));

            bool letterExists = false;

            for(int i = 0;i < gameData.Word.Length; i++)
            {
                if (gameData.HasSameLetterAtIndex(letter,i))
                {
                    Events.Add(new RevealLetterEvent(gameData, letter, i));
                    letterExists = true;
                }
            }

            if (!letterExists)
            {
                Events.Add(new WrongGuessEvent(gameData));
                if (gameData.NbWrongGuesses > GameData.NB_WRONG_TRIES_FOR_LOSING)
                {
                    Events.Add(new LoseEvent(gameData));
                }
            }

            
        }
    }
}
