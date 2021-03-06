﻿// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Bot.Schema.Teams
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Messaging extension action
    /// </summary>
    public partial class MessagingExtensionAction : TaskModuleRequest
    {
        /// <summary>
        /// Initializes a new instance of the MessagingExtensionAction class.
        /// </summary>
        public MessagingExtensionAction()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MessagingExtensionAction class.
        /// </summary>
        /// <param name="data">User input data. Free payload with key-value
        /// pairs.</param>
        /// <param name="context">Current user context, i.e., the current
        /// theme</param>
        /// <param name="commandId">Id of the command assigned by Bot</param>
        /// <param name="commandContext">The context from which the command
        /// originates. Possible values include: 'message', 'compose',
        /// 'commandbox'</param>
        /// <param name="botMessagePreviewAction">Bot message preview action
        /// taken by user. Possible values include: 'edit', 'send'</param>
        /// <param name="botActivityPreview">A collection of bot activities.</param>
        /// <param name="messagePayload">Message content sent as part of the
        /// command request.</param>
        public MessagingExtensionAction(object data = default(object), TaskModuleRequestContext context = default(TaskModuleRequestContext), string commandId = default(string), string commandContext = default(string), string botMessagePreviewAction = default(string), IList<Activity> botActivityPreview = default(IList<Activity>), MessageActionsPayload messagePayload = default(MessageActionsPayload))
            : base(data, context)
        {
            CommandId = commandId;
            CommandContext = commandContext;
            BotMessagePreviewAction = botMessagePreviewAction;
            BotActivityPreview = botActivityPreview;
            MessagePayload = messagePayload;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets id of the command assigned by Bot
        /// </summary>
        [JsonProperty(PropertyName = "commandId")]
        public string CommandId { get; set; }

        /// <summary>
        /// Gets or sets the context from which the command originates.
        /// Possible values include: 'message', 'compose', 'commandbox'
        /// </summary>
        [JsonProperty(PropertyName = "commandContext")]
        public string CommandContext { get; set; }

        /// <summary>
        /// Gets or sets bot message preview action taken by user. Possible
        /// values include: 'edit', 'send'
        /// </summary>
        [JsonProperty(PropertyName = "botMessagePreviewAction")]
        public string BotMessagePreviewAction { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "botActivityPreview")]
        public IList<Activity> BotActivityPreview { get; set; }

        /// <summary>
        /// Gets or sets message content sent as part of the command request.
        /// </summary>
        [JsonProperty(PropertyName = "messagePayload")]
        public MessageActionsPayload MessagePayload { get; set; }

        /// <summary>
        /// Gets or sets state parameter passed back to the bot after authentication flow.
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
    }
}
