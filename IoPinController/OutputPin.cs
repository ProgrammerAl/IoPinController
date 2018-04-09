﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IoPinController.FileUtils;
using IoPinController.Utils;

namespace IoPinController
{
    public abstract class OutputPin : Pin
    {
        public OutputPin(int number, IAsyncFileUtil fileWriter, IIoPinControllerLogger logger) : base(number, fileWriter, logger)
        {
        }

        public override PinDirectionType PinDirection => PinDirectionType.Output;

        public OutputModeType OutputMode { get; private set; }

        public async Task SetOutputModeAsync(OutputModeType outputMode)
        {
            if (OutputMode != outputMode)
            {
                OutputMode = outputMode;
                await OnSetOutputModeAsync(outputMode);
            }
        }

        protected abstract Task OnSetOutputModeAsync(OutputModeType outputMode);
    }
}