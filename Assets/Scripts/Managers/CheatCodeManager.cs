namespace Managers
{
    public class CheatCodeManager : SingletonMonoBehaviour<CheatCodeManager>
    {
        #region Variables

        private bool isFuelCheatOn;

        #endregion


        #region Properties

        public bool IsFuelCheatOn => isFuelCheatOn;

        #endregion


        #region Unity lifecycle

        private void Start()
        {
            isFuelCheatOn = false;
        }

        #endregion


        #region Public Methods

        public void TurnFuelCheat()
        {
            isFuelCheatOn = !isFuelCheatOn;
        }

        #endregion
    }
}
