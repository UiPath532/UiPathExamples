using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UiPath.CodedWorkflows;
using UiPath.CodedWorkflows.Interfaces;
using UiPath.Activities.Contracts;
using UiPathAdvanceFeatures;

[assembly: WorkflowRunnerServiceAttribute(typeof(UiPathAdvanceFeatures.WorkflowRunnerService))]
namespace UiPathAdvanceFeatures
{
    public class WorkflowRunnerService
    {
        private readonly ICodedWorkflowServices _services;
        public WorkflowRunnerService(ICodedWorkflowServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Invokes the CodeStage.xaml
        /// </summary>
        public void CodeStage()
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"CodeStage.xaml", new Dictionary<string, object>{}, default, default, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the Main.xaml
        /// </summary>
        public void Main()
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"Main.xaml", new Dictionary<string, object>{}, default, default, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the PowerShell.xaml
        /// </summary>
        public void PowerShell()
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"PowerShell.xaml", new Dictionary<string, object>{}, default, default, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the PythonSolution.xaml
        /// </summary>
        public void PythonSolution()
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"PythonSolution.xaml", new Dictionary<string, object>{}, default, default, default, GetAssemblyName());
        }

        private string GetAssemblyName()
        {
            var assemblyProvider = _services.Container.Resolve<ILibraryAssemblyProvider>();
            return assemblyProvider.GetLibraryAssemblyName(GetType().Assembly);
        }
    }
}