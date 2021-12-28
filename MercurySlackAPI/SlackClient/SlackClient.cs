using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MercurySlackAPI.Models;

namespace MercurySlackAPI
{
    /**
     * <summery>This class is designed to make using Slack API functions more easily</summery>
     */
    public class SlackClient
    {
        private HttpClient client { get; set; }

        /**
         * <summery>Initiates the SlackClient class, using the token parameter</summery>
         * <param name="token">This is the token that appears under "Bot User OAuth Token" in the OAuth&Permissions page of the slack app</param>
         */
        public SlackClient(string token)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }


        /**
         * <summery>Sends the slack message asynchronously to the specified channel</summery>
         * <param name="channel">The channel the message will be sent to</param>
         * <param name="msg">The message that will be sent</param>
         */
        public async Task<string> SendMessageAsync(Message msg, string channel)
        {
            msg.channel = channel;
            return await SendMessageAsync(msg);
        }


        /**
         * <summery>Sends the slack message asynchronously to the specified channel</summery>
         * <param name="channel">The channel the message will be sent to</param>
         * <param name="msg">The message that will be sent</param>
         */
        public async Task<string> SendMessageAsync(string text, string channel)
        {
            var msg = new Message();
            msg.text = text;
            msg.channel = channel;
            msg.as_user = true;
            return await SendMessageAsync(msg);
        }


        /**
         * <summery>Sends the slack message asynchronously</summery>
         * <param name="msg">The message that will be sent</param>
         */
        public async Task<string> SendMessageAsync(Message msg)
        {
            // serialize method parameters to JSON
            string content = JsonConvert.SerializeObject(msg);
            var httpContent = new StringContent(
                content,
                Encoding.UTF8,
                "application/json"
            );

            // send message to API
            var response = await client.PostAsync("https://slack.com/api/chat.postMessage", httpContent);

            // fetch response from API
            var responseJson = await response.Content.ReadAsStringAsync();

            // convert JSON response to object
            MessageResponse messageResponse =
                JsonConvert.DeserializeObject<MessageResponse>(responseJson);
            Console.WriteLine(messageResponse.error);
            // throw exception if sending failed
            if (!messageResponse.ok)
                return $"message sending failed. Error:\n{messageResponse.error}\nmessage content:\n{content}";
            return "message successfully sent";
        }


        /**
         * <summery>Updates the slack message asynchronously</summery>
         * <param name="payload">The payload with the modified message to send back as the updated message</param>
         */
        public async Task<string> UpdateMessageAsync(InteractionPayload payload)
        {
            var msg = payload.message;
            msg.text = null;
            msg.as_user = true;
            msg.bot_id = null;
            msg.channel = payload.channel.id;
            msg.team = null;
            msg.type = null;
            msg.user = null;

            return await UpdateMessageAsync(msg);
        }


        /**
         * <summery>Updates the slack message asynchronously</summery>
         * <param name="msg">The message to send back as the updated message</param>
         * <remarks>This overload can easily be screwed up if used incorrectly.
         * In most cases, it's recommended to use the overload that receives the payload instead</remarks>
         */
        public async Task<string> UpdateMessageAsync(Message msg)
        {
            // serialize method parameters to JSON
            var content = JsonConvert.SerializeObject(msg);
            var httpContent = new StringContent(
                content,
                Encoding.UTF8,
                "application/json"
            );

            // send message to API
            var response = await client.PostAsync("https://slack.com/api/chat.update", httpContent);

            // fetch response from API
            var responseJson = await response.Content.ReadAsStringAsync();

            // convert JSON response to object
            MessageResponse messageResponse =
                JsonConvert.DeserializeObject<MessageResponse>(responseJson);
            Console.WriteLine(messageResponse.error);

            // throw exception if sending failed
            if (!messageResponse.ok)
                return $"message update failed. Error:\n{messageResponse.error}\nmessage content:\n{content}";
            return "message successfully updated";
        }



        /**
         * <summery>Gets the profile of the <paramref name="userId"/> specified asynchronously</summery>
         * <param name="userId">The user id to get the profile for</param>
         */
        public async Task<Profile> GetProfileAsync(string userId)
        {
            string requestUri = "https://slack.com/api/users.profile.get";
            var content = new Dictionary<string, string>();
            content.Add("user", userId);
            var form = new FormUrlEncodedContent(content);

            var response = await client.PostAsync(requestUri, form);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetProfileResponse>(json);
            var profile = result.profile;

            return profile;
        }


        /**
         * <summery>Gets the profile ids of the <paramref name="channelId"/> specified channel asynchronously</summery>
         * <param name="channelId">The channel to get the user ids of</param>
         */
        public async Task<List<string>> GetConvMembersAsync(string channelId)
        {
            string requestUri = "https://slack.com/api/conversations.members";
            var content = new Dictionary<string, string>();
            content.Add("channel", channelId);
            var form = new FormUrlEncodedContent(content);

            var response = await client.PostAsync(requestUri, form);

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ConversationMembersResponse>(json);

            var users = result.members;

            // In case of over a 100 members
            content.Add("cursor", result.response_metadata.next_cursor);
            while (!result.response_metadata.next_cursor.Equals(""))
            {
                response = await client.PostAsync(requestUri, form);

                json = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<ConversationMembersResponse>(json);

                users.AddRange(result.members);
                content["cursor"] = result.response_metadata.next_cursor;
            }

            return users;
        }
    }
}
