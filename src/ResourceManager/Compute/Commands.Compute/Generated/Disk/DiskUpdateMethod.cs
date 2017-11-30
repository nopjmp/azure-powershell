// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class InvokeAzureComputeMethodCmdlet : ComputeAutomationBaseCmdlet
    {
        protected object CreateDiskUpdateDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pDiskName = new RuntimeDefinedParameter();
            pDiskName.Name = "DiskName";
            pDiskName.ParameterType = typeof(string);
            pDiskName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true
            });
            pDiskName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("DiskName", pDiskName);

            var pDisk = new RuntimeDefinedParameter();
            pDisk.Name = "Disk";
            pDisk.ParameterType = typeof(DiskUpdate);
            pDisk.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = true
            });
            pDisk.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("Disk", pDisk);

            var pArgumentList = new RuntimeDefinedParameter();
            pArgumentList.Name = "ArgumentList";
            pArgumentList.ParameterType = typeof(object[]);
            pArgumentList.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByStaticParameters",
                Position = 4,
                Mandatory = true
            });
            pArgumentList.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ArgumentList", pArgumentList);

            return dynamicParameters;
        }

        protected void ExecuteDiskUpdateMethod(object[] invokeMethodInputParameters)
        {
            string resourceGroupName = (string)ParseParameter(invokeMethodInputParameters[0]);
            string diskName = (string)ParseParameter(invokeMethodInputParameters[1]);
            DiskUpdate disk = (DiskUpdate)ParseParameter(invokeMethodInputParameters[2]);
            Disk diskOrg = (Disk)ParseParameter(invokeMethodInputParameters[3]);

            var result = (disk == null)
                         ? DisksClient.CreateOrUpdate(resourceGroupName, diskName, diskOrg)
                         : DisksClient.Update(resourceGroupName, diskName, disk);
            WriteObject(result);
        }
    }

    public partial class NewAzureComputeArgumentListCmdlet : ComputeAutomationBaseCmdlet
    {
        protected PSArgument[] CreateDiskUpdateParameters()
        {
            string resourceGroupName = string.Empty;
            string diskName = string.Empty;
            DiskUpdate disk = new DiskUpdate();

            return ConvertFromObjectsToArguments(
                 new string[] { "ResourceGroupName", "DiskName", "Disk" },
                 new object[] { resourceGroupName, diskName, disk });
        }
    }

    [Cmdlet(VerbsData.Update, "AzureRmDisk", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSDisk))]
    public partial class UpdateAzureRmDisk : ComputeAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.DiskName, VerbsData.Update))
                {

                    string resourceGroupName = this.ResourceGroupName;
                    string diskName = this.DiskName;
                    DiskUpdate diskupdate = new DiskUpdate();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<PSDiskUpdate, DiskUpdate>(this.DiskUpdate, diskupdate);
                    Disk disk = new Disk();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<PSDisk, Disk>(this.Disk, disk);

                    var result = (this.DiskUpdate == null)
                                 ? DisksClient.CreateOrUpdate(resourceGroupName, diskName, disk)
                                 : DisksClient.Update(resourceGroupName, diskName, diskupdate);
                    var psObject = new PSDisk();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<Disk, PSDisk>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Parameter(
            ParameterSetName = "FriendMethod",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [AllowNull]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Parameter(
            ParameterSetName = "FriendMethod",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Alias("Name")]
        [AllowNull]
        public string DiskName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            ValueFromPipeline = true)]
        [AllowNull]
        public PSDiskUpdate DiskUpdate { get; set; }

        [Parameter(
            ParameterSetName = "FriendMethod",
            Position = 4,
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            ValueFromPipeline = true)]
        [AllowNull]
        public PSDisk Disk { get; set; }
    }
}
