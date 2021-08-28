using System;
using System.Collections.Generic;
using System.Text;

namespace GSP
{
    class WaygateManager
    {
        List<Waygate> waygates;
        public WaygateManager()
        {
            loadWaygates();
        }

        public Object[] getComboList()
        {
            Object[] objectArr = new Object[waygates.Count];
            for(int i = 0; i < waygates.Count; ++i)
            {
                objectArr[i] = waygates[i].getData("Location");
            }
            return objectArr;
        } 
        public void loadWaygates()
        {
            waygates = new List<Waygate>();
            waygates.Add(new Waygate("Mining Town", "Knoxmoor", "Tenebris", "Cave of the Dead Lady", "Fort Saward"));
            waygates.Add(new Waygate("Outpost Adera", "Forest", "Fort Saward", "Quarry", "Exolesco"));
            waygates.Add(new Waygate("Fort Saward", "Cave of the Dead Lady", "Forest", "Outpost Adera", "Quarry"));
            waygates.Add(new Waygate("Cave of the Dead Lady", "Knoxmoor", "Tenebris", "Mining Town", "Fort Saward"));
            waygates.Add(new Waygate("Sanctuary of Peace", "Forest", "Fort Saward", "Quarry", "Fort Erie"));
            waygates.Add(new Waygate("Tenebris", "Knoxmoor", "Mining Town", "Cave of the Dead Lady", "Kauri"));
            waygates.Add(new Waygate("Quarry", "Mining Town", "Fort Saward", "Outpost Adera", "Exolesco"));
            waygates.Add(new Waygate("Kauri", "Tenebris", "Mining Town", "Anvalia", "Desert Canyon Sanctuary"));
            waygates.Add(new Waygate("Clarce", "Cave of the Dead Lady", "Forest", "Outpost Adera", "Snow Mountain"));
            waygates.Add(new Waygate("Desert Canyon Sanctuary", "Tenebris", "Patchwork", "Anvalia", "Kauri"));
            waygates.Add(new Waygate("Knoxmoor", "Tenebris", "Mining Town", "Fort Erie", "Clarce"));
            waygates.Add(new Waygate("Forest", "Desert Castle", "Grimdale Farm", "Sanctuary of Peace", "Fort Saward"));
            waygates.Add(new Waygate("Fort Erie", "Secret Stash", "Forest", "Clarce", "Snow Mountain"));
            waygates.Add(new Waygate("Exolesco", "Desert Castle", "Grimdale Farm", "Sanctuary of Peace", "Sanctuary of Peace"));
            waygates.Add(new Waygate("Snow Mountain", "Secret Stash", "Patchwork", "Clarce", "Fort Erie"));
            waygates.Add(new Waygate("Patchwork", "Secret Stash", "Anvalia", "Forest", "Snow Mountain"));
            waygates.Add(new Waygate("Anvalia", "Patchwork", "Desert Canyon Sanctuary", "Exolesco", "Snow Mountain"));
            waygates.Add(new Waygate("Grimdale Farm", "Desert Castle", "Forest", "Exolesco", "Snow Mountain"));
            waygates.Add(new Waygate("Desert Castle", "Secret Stash", "Grimdale Farm", "Forest", "Exolesco"));
            waygates.Add(new Waygate("Secret Stash", "Desert Castle", "Patchwork", "Anvalia", "Fort Erie"));
        }
        public List<Waygate> getWaygates()
        {
            List<Waygate> waygatesCopy = new List<Waygate>(waygates.Count);

            waygates.ForEach((item) =>
            {
                waygatesCopy.Add(new Waygate(item.getData("Location"),item.getData("Alpha"), item.getData("Beta"), item.getData("Theta"), item.getData("Omega")));
            });
            return waygatesCopy;
        }
        public Waygate getWaygate(String location)
        {
            foreach(Waygate wg in waygates)
            {
                if (wg.getData("Location").Equals(location))
                {

                    return new Waygate(wg.getData("Location"), wg.getData("Alpha"), wg.getData("Beta"), wg.getData("Theta"), wg.getData("Omega"));
                }
            }
            return null;
        }
        
    }
}
