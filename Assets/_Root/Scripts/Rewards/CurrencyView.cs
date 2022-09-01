using UnityEngine;

namespace Rewards
{
    internal class CurrencyView : MonoBehaviour
    {
        private const string IronKey = nameof(IronKey);
        private const string UraniumKey = nameof(UraniumKey);
        private const string CrystalKey = nameof(CrystalKey);

        private static CurrencyView _instance;
        public static CurrencyView Instance => _instance;

        [SerializeField] private CurrencySlotView _currencyIron;
        [SerializeField] private CurrencySlotView _currentUranium;
        [SerializeField] private CurrencySlotView _currentCristal;

        private int Iron
        {
            get => PlayerPrefs.GetInt(IronKey);
            set => PlayerPrefs.SetInt(IronKey, value);
        }

        private int Uranium
        {
            get => PlayerPrefs.GetInt(UraniumKey);
            set => PlayerPrefs.SetInt(UraniumKey, value);
        }

        private int Crystal
        {
            get => PlayerPrefs.GetInt(CrystalKey);
            set => PlayerPrefs.SetInt(CrystalKey, value);
        }

        private void Awake() =>
            _instance = this;

        private void OnDestroy() =>
            _instance = null;

        private void Start()
        {
            _currencyIron.SetData(Iron);
            _currentUranium.SetData(Uranium);
            _currentCristal.SetData(Crystal);
        }


        public void AddIron(int value)
        {
            Iron += value;
            _currencyIron.SetData(Iron);
        }

        public void AddUranium(int value)
        {
            Uranium += value;
            _currentUranium.SetData(Uranium);
        }

        public void AddCrystal(int value)
        {
            Crystal += value;
            _currentCristal.SetData(Crystal);
        }
    }
}
