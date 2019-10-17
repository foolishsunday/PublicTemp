using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XPCar.Prj.Model;

namespace XPCar.Prj.Controller
{
    public delegate void UpdateHandShakeHandle(GetHandShake data);
    public delegate void UpdateChargeParaHandle(GetChargePara data);
    public delegate void UpdateChargingHandle(GetCharging data);
    public delegate void UpdateChargeStopHandle(GetChargeStop data);
    public delegate void UpdateInteropCtrlHandle(SettingDC data);
    public delegate void UpdateDCItemHandle();
    public delegate void UpdateAlarmHandle(string text);
    public delegate void UpdateACHandle(GetAC data);
    public delegate void UpdateACResultHandle();
    public delegate void UpdateACInteropHandle(GetACInterop data);
    public delegate void UpdateVersionHandle(string ver, string flowno);
    public delegate void FinishConsistHandle();
    public class GeneralController
    {
        public event UpdateHandShakeHandle UpdateHandShake;
        public event UpdateChargeParaHandle UpdateChargePara;
        public event UpdateChargingHandle UpdateCharging;
        public event UpdateChargeStopHandle UpdateChargeStop;
        public event UpdateInteropCtrlHandle UpdateInteropCtrl;
        public event UpdateDCItemHandle UpdateDCItem;
        public event UpdateAlarmHandle UpdateAlarm;
        public event UpdateACHandle UpdateAC;
        public event UpdateACResultHandle UpdateACResult;
        public event UpdateACInteropHandle UpdateACInterop;
        public event UpdateVersionHandle UpdateVersion;
        public event FinishConsistHandle FinishConsist;
        public void RefreshHandshake(GetHandShake data)
        {
            if (UpdateHandShake != null)
                UpdateHandShake(data);
        }
        public void RefreshChargePara(GetChargePara data)
        {
            if (UpdateChargePara != null)
                UpdateChargePara(data);
        }
        public void RefreshCharging(GetCharging data)
        {
            if (UpdateCharging != null)
                UpdateCharging(data);
        }
        public void RefreshChargeStop(GetChargeStop data)
        {
            if (UpdateChargeStop != null)
                UpdateChargeStop(data);
        }
        public void RefreshInteropCtrl(SettingDC data)
        {
            if (UpdateInteropCtrl != null)
                UpdateInteropCtrl(data);
        }
        public void RefreshDCItem()
        {
            if (UpdateDCItem != null)
                UpdateDCItem();
        }
        public void RefreshAlarm(string text)
        {
            if (UpdateAlarm != null)
                UpdateAlarm(text);
        }
        public void RefreshUpdateAC(GetAC data)
        {
            if (UpdateAC != null)
                UpdateAC(data);
        }
        public void RefreshUpdateACResult()
        {
            if (UpdateACResult != null)
                UpdateACResult();
        }
        public void RefreshUpdateACInterop(GetACInterop data)
        {
            if (UpdateACInterop != null)
                UpdateACInterop(data);
        }
        public void RefreshUpdateVersion(string data, string flowNo)
        {
            if (UpdateVersion != null)
                UpdateVersion(data, flowNo);
        }
        public void RefreshAutoConsistResult()
        {
            if (FinishConsist != null)
                FinishConsist();
        }
    }
}
