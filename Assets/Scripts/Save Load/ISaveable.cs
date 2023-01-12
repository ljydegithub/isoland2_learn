public interface ISaveable
{
    void SavableRegister();

    GameSaveData GenerateSaveData(GameSaveData saveData);

    void RestoreGameData(GameSaveData saveData);
}
