using UnityEngine;

public class ActivateOverridedMethodsByButton : MonoBehaviour
{
    protected virtual void MenuInheritLogic(ActivateOverridedMethodsByButtonContainer _activateOverridedMethodsByButtonContainer)
    {
        if (_activateOverridedMethodsByButtonContainer.Menu.gameObject.activeSelf && _activateOverridedMethodsByButtonContainer.DisableAllMenuByButton.IsExitMenuOpened())
        {
            _activateOverridedMethodsByButtonContainer.ExitMenu.SetActive(false);
            return;
        }

        if (!_activateOverridedMethodsByButtonContainer.Menu.gameObject.activeSelf && !_activateOverridedMethodsByButtonContainer.TapOutsideToCloseAllWindows.gameObject.activeSelf)
        {
            DisableAllMenu(_activateOverridedMethodsByButtonContainer);
            SetOppositeActiveConditionForTapOutsideToCloseAllWindowsGO(_activateOverridedMethodsByButtonContainer);
            SetFalseConditionOnMainSafeMenu(_activateOverridedMethodsByButtonContainer);
        }

        else if (!_activateOverridedMethodsByButtonContainer.Menu.gameObject.activeSelf)
        {
            DisableAllMenu(_activateOverridedMethodsByButtonContainer);
        }

        if (_activateOverridedMethodsByButtonContainer.Menu.gameObject.activeSelf && _activateOverridedMethodsByButtonContainer.TapOutsideToCloseAllWindows.gameObject.activeSelf)
        {
            SetActiveConditionOnMainSafeMenu(_activateOverridedMethodsByButtonContainer);
            SetOppositeActiveConditionForTapOutsideToCloseAllWindowsGO(_activateOverridedMethodsByButtonContainer);
        }
            
        SetOppositeActiveConditionOnMenu(_activateOverridedMethodsByButtonContainer);
    }

    protected void SetActiveConditionOnMainSafeMenu(ActivateOverridedMethodsByButtonContainer _activateOverridedMethodsByButtonContainer)
    {
        _activateOverridedMethodsByButtonContainer.MainSafeMenu.SetActive(true);
    }

    protected void SetFalseConditionOnMainSafeMenu(ActivateOverridedMethodsByButtonContainer _activateOverridedMethodsByButtonContainer)
    {
        _activateOverridedMethodsByButtonContainer.MainSafeMenu.SetActive(false);
    }

    protected virtual void SetOppositeActiveConditionOnMenu(GameObject menu, ISetOppositeActiveConditionMenu _IsetOppositeActiveConditionMenu)
    {
        _IsetOppositeActiveConditionMenu = menu.GetComponent<ISetOppositeActiveConditionMenu>();
        if (_IsetOppositeActiveConditionMenu == null)
        {
            Debug.Log("Error, The SetOppositeActiveConditionByButton cannot find an " + _IsetOppositeActiveConditionMenu + " interface in that object");
            return;
        }

        _IsetOppositeActiveConditionMenu.SetOppositeActiveCondition();
    }

    protected virtual void SetOppositeActiveConditionOnMenu(ActivateOverridedMethodsByButtonContainer _activateOverridedMethodsByButtonContainer)
    {
        _activateOverridedMethodsByButtonContainer.IsetOppositeActiveConditionMenu = _activateOverridedMethodsByButtonContainer.Menu.GetComponent<ISetOppositeActiveConditionMenu>();
        if (_activateOverridedMethodsByButtonContainer.IsetOppositeActiveConditionMenu == null)
        {
            Debug.Log("Error, The SetOppositeActiveConditionByButton cannot find an " + _activateOverridedMethodsByButtonContainer.IsetOppositeActiveConditionMenu + " interface in that object");
            return;
        }

        _activateOverridedMethodsByButtonContainer.IsetOppositeActiveConditionMenu.SetOppositeActiveCondition();
    }

    protected virtual void DisableAllMenu(DisableAllMenuByButton _disableAllMenuByButton)
    {
        _disableAllMenuByButton.DisableAllMenu();
    }

    protected virtual void DisableAllMenu(ActivateOverridedMethodsByButtonContainer _activateOverridedMethodsByButtonContainer)
    {
        _activateOverridedMethodsByButtonContainer.DisableAllMenuByButton.DisableAllMenu();
    }

    protected virtual void SetOppositeActiveConditionForTapOutsideToCloseAllWindowsGO(TapOutsideToCloseAllWindows _tapOutsideToCloseAllWindows)
    {
        _tapOutsideToCloseAllWindows.SetActiveTapOutsideToCloseAllWindows();
    }

    protected virtual void SetOppositeActiveConditionForTapOutsideToCloseAllWindowsGO(ActivateOverridedMethodsByButtonContainer _activateOverridedMethodsByButtonContainer)
    {
        _activateOverridedMethodsByButtonContainer.TapOutsideToCloseAllWindows.SetActiveTapOutsideToCloseAllWindows();
    }
}

public class ActivateOverridedMethodsByButtonContainer
{
    GameObject _menu;
    public GameObject Menu { get => _menu; set => _menu = value; }

    GameObject _exitMenu;
    public GameObject ExitMenu { get => _exitMenu; set => _exitMenu = value; }

    GameObject _mainSafeMenu;
    public GameObject MainSafeMenu { get => _mainSafeMenu; set => _mainSafeMenu = value; }

    ISetOppositeActiveConditionMenu _IsetOppositeActiveConditionMenu;
    public ISetOppositeActiveConditionMenu IsetOppositeActiveConditionMenu { get => _IsetOppositeActiveConditionMenu; set => _IsetOppositeActiveConditionMenu = value; }

    DisableAllMenuByButton _disableAllMenuByButton;
    public DisableAllMenuByButton DisableAllMenuByButton => _disableAllMenuByButton;

    TapOutsideToCloseAllWindows _tapOutsideToCloseAllWindows;
    public TapOutsideToCloseAllWindows TapOutsideToCloseAllWindows => _tapOutsideToCloseAllWindows;

    public ActivateOverridedMethodsByButtonContainer(GameObject _menu, ISetOppositeActiveConditionMenu _IsetOppositeActiveConditionMenu, DisableAllMenuByButton _disableAllMenuByButton, TapOutsideToCloseAllWindows _tapOutsideToCloseAllWindows, GameObject _exitMenu, GameObject _mainSafeMenu)
    {
        //Game Objects
        this._menu = _menu;
        this._exitMenu = _exitMenu; ;
        this._mainSafeMenu = _mainSafeMenu;

        //Scripts
        this._IsetOppositeActiveConditionMenu = _IsetOppositeActiveConditionMenu;
        this._disableAllMenuByButton = _disableAllMenuByButton;
        this._tapOutsideToCloseAllWindows = _tapOutsideToCloseAllWindows;
    }
}