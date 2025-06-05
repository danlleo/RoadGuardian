﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using Content.Global.Scripts;

namespace Core.SceneLoaderServiceModule.Scripts
{
    public class SceneLoaderServiceFacade : ISceneLoaderService
    {
        private readonly BuildInSceneLoaderService _buildInSceneLoaderService;
        private readonly AddressablesSceneLoaderService _addressablesSceneLoaderService;

        public SceneLoaderServiceFacade(BuildInSceneLoaderService buildInSceneLoaderService,
            AddressablesSceneLoaderService addressablesSceneLoaderService)
        {
            _addressablesSceneLoaderService = addressablesSceneLoaderService;
            _buildInSceneLoaderService = buildInSceneLoaderService;
        }

        public async UniTask LoadSceneAsync(string sceneToLoad, bool unloadRedundant)
        {
            if (Address.Scenes.AllKeys.Contains(sceneToLoad))
                await _addressablesSceneLoaderService.LoadSceneAsync(sceneToLoad, unloadRedundant);
            else
                await _buildInSceneLoaderService.LoadSceneAsync(sceneToLoad, unloadRedundant);
        }

        public async UniTask LoadScenesAsync(List<string> scenesToLoad, string activeScene, bool unloadRedundant)
        {
            List<string> scenesNotInAddressables = scenesToLoad.Except(Address.Scenes.AllKeys).ToList();

            if (scenesNotInAddressables.Any() is false)
            {
                await _addressablesSceneLoaderService.LoadScenesAsync(scenesToLoad, unloadRedundant);
                SetActiveScene(activeScene);
                return;
            }

            if (scenesNotInAddressables.Count == scenesToLoad.Count)
            {
                await _buildInSceneLoaderService.LoadScenesAsync(scenesToLoad, unloadRedundant);
                SetActiveScene(activeScene);
                return;
            }

            await _buildInSceneLoaderService.LoadScenesAsync(scenesNotInAddressables, unloadRedundant);
            await _addressablesSceneLoaderService.LoadScenesAsync(scenesToLoad.Except(scenesNotInAddressables).ToList(),
                unloadRedundant);
            SetActiveScene(activeScene);
        }

        public async UniTask ReloadCurrentScene()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (Address.Scenes.AllKeys.Contains(currentSceneName))
                await _addressablesSceneLoaderService.LoadSceneAsync(currentSceneName, true);
            else
                await _buildInSceneLoaderService.LoadSceneAsync(currentSceneName, true);
        }

        private void SetActiveScene(string activeScene)
        {
            if (SceneManager.GetActiveScene().name == activeScene)
                return;

            Scene newActiveScene = SceneManager.GetSceneByName(activeScene);
            SceneManager.SetActiveScene(newActiveScene);
        }

        public async UniTask UnloadSceneAsync(string sceneToUnload)
        {
            if (Address.Scenes.AllKeys.Contains(sceneToUnload))
                await _addressablesSceneLoaderService.UnloadSceneAsync(sceneToUnload);
            else
                await _buildInSceneLoaderService.UnloadSceneAsync(sceneToUnload);
        }

        public async UniTask UnloadScenesAsync(List<string> scenesToUnload)
        {
            List<string> scenesNotInAddressables = scenesToUnload.Except(Address.Scenes.AllKeys)
                .ToList();

            if (scenesNotInAddressables.Any() is false)
            {
                await _addressablesSceneLoaderService.UnloadScenesAsync(scenesToUnload);
                return;
            }

            if (scenesNotInAddressables.Count == scenesToUnload.Count)
            {
                await _buildInSceneLoaderService.UnloadScenesAsync(scenesToUnload);
                return;
            }

            await _buildInSceneLoaderService.UnloadScenesAsync(scenesNotInAddressables);
            await _addressablesSceneLoaderService.UnloadScenesAsync(scenesToUnload.Except(scenesNotInAddressables)
                .ToList());
        }
    }
}