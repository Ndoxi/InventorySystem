using IS.Core.Gameplay;

namespace IS.Services
{
    public interface IAttackSystem
    {
        void Attack(TrainingDummyView trainingDummy);
        void AddMultiHit();
    }
}
