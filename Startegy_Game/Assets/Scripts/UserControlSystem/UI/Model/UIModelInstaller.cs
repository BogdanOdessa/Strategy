using System.ComponentModel;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class UIModelInstaller : MonoInstaller
    {
        [SerializeField] private AssetsInstaller _assetsInstaller;
        public override void InstallBindings()
        {
             Container.Bind<AssetsInstaller>().FromInstance(_assetsInstaller);
            
             Container.Bind<AssetsContext>().FromInstance(_assetsInstaller._assetsContext);
             Container.Bind<Vector3Value>().FromInstance(_assetsInstaller._groundClickValue);
             Container.Bind<UnitCommandsSettings>().FromInstance(_assetsInstaller._unitCommandsSettings);
             Container.Bind<AttackableValue>().FromInstance(_assetsInstaller._attackableValue);

             Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
                .To<ProduceUnitCommandCommandCreator>().AsTransient();
             Container.Bind<CommandCreatorBase<IMoveCommand>>()
                .To<MoveCommandCommandCreator>().AsTransient();
             Container.Bind<CommandCreatorBase<IPatrolCommand>>()
                .To<PatrolCommandCreator>().AsTransient();
             Container.Bind<CommandCreatorBase<IStopCommand>>()
                .To<StopCommandCreator>().AsTransient();
            
             Container.Bind<CommandCreatorBase<IAttackCommand>>()
                .To<AttackCommandCreator>().AsTransient();
            
             Container.Bind<CommandButtonsModel>().AsTransient();
        }

        #region OldRealistaionForMe

        // [SerializeField] private AssetsContext _legacyContext;
        // [SerializeField] private Vector3Value _vector3Value;
        // [SerializeField] private UnitCommandsSettings _unitCommandsSettings;
        // [SerializeField] private AttackableValue _attackableValue;
        
        // Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        // Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        // Container.Bind<UnitCommandsSettings>().FromInstance(_unitCommandsSettings);
        // Container.Bind<AttackableValue>().FromInstance(_attackableValue);

        #endregion
    }
}