/* tslint:disable */
/* eslint-disable */
/**
 * API Artisashop
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


import * as runtime from '../runtime';
import type {
  ChatMessage,
  ChatPreview,
  CreateChatMessage,
} from '../models';
import {
    ChatMessageFromJSON,
    ChatMessageToJSON,
    ChatPreviewFromJSON,
    ChatPreviewToJSON,
    CreateChatMessageFromJSON,
    CreateChatMessageToJSON,
} from '../models';

export interface ApiChatHistoryGetRequest {
    users?: Array<string>;
}

export interface ApiChatMsgIdDeleteRequest {
    msgId: number;
}

export interface ApiChatMsgIdGetRequest {
    msgId: number;
}

export interface ApiChatPatchRequest {
    msgId?: number;
    content?: string;
}

export interface ApiChatPostRequest {
    createChatMessage?: CreateChatMessage;
}

/**
 * 
 */
export class ChatApi extends runtime.BaseAPI {

    /**
     */
    async apiChatHistoryGetRaw(requestParameters: ApiChatHistoryGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<ChatMessage>>> {
        const queryParameters: any = {};

        if (requestParameters.users) {
            queryParameters['users'] = requestParameters.users;
        }

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/chat/history`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(ChatMessageFromJSON));
    }

    /**
     */
    async apiChatHistoryGet(requestParameters: ApiChatHistoryGetRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<ChatMessage>> {
        const response = await this.apiChatHistoryGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiChatListGetRaw(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<ChatPreview>>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/chat/list`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(ChatPreviewFromJSON));
    }

    /**
     */
    async apiChatListGet(initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<ChatPreview>> {
        const response = await this.apiChatListGetRaw(initOverrides);
        return await response.value();
    }

    /**
     */
    async apiChatMsgIdDeleteRaw(requestParameters: ApiChatMsgIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<string>> {
        if (requestParameters.msgId === null || requestParameters.msgId === undefined) {
            throw new runtime.RequiredError('msgId','Required parameter requestParameters.msgId was null or undefined when calling apiChatMsgIdDelete.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/chat/{msgId}`.replace(`{${"msgId"}}`, encodeURIComponent(String(requestParameters.msgId))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.TextApiResponse(response) as any;
    }

    /**
     */
    async apiChatMsgIdDelete(requestParameters: ApiChatMsgIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<string> {
        const response = await this.apiChatMsgIdDeleteRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiChatMsgIdGetRaw(requestParameters: ApiChatMsgIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ChatMessage>> {
        if (requestParameters.msgId === null || requestParameters.msgId === undefined) {
            throw new runtime.RequiredError('msgId','Required parameter requestParameters.msgId was null or undefined when calling apiChatMsgIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/chat/{msgId}`.replace(`{${"msgId"}}`, encodeURIComponent(String(requestParameters.msgId))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ChatMessageFromJSON(jsonValue));
    }

    /**
     */
    async apiChatMsgIdGet(requestParameters: ApiChatMsgIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ChatMessage> {
        const response = await this.apiChatMsgIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiChatPatchRaw(requestParameters: ApiChatPatchRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ChatMessage>> {
        const queryParameters: any = {};

        if (requestParameters.msgId !== undefined) {
            queryParameters['msgId'] = requestParameters.msgId;
        }

        if (requestParameters.content !== undefined) {
            queryParameters['content'] = requestParameters.content;
        }

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/chat`,
            method: 'PATCH',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ChatMessageFromJSON(jsonValue));
    }

    /**
     */
    async apiChatPatch(requestParameters: ApiChatPatchRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ChatMessage> {
        const response = await this.apiChatPatchRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiChatPostRaw(requestParameters: ApiChatPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ChatMessage>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/chat`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: CreateChatMessageToJSON(requestParameters.createChatMessage),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ChatMessageFromJSON(jsonValue));
    }

    /**
     */
    async apiChatPost(requestParameters: ApiChatPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ChatMessage> {
        const response = await this.apiChatPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
