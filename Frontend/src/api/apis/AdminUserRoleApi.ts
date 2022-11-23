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
  StringIdentityUserRole,
} from '../models';
import {
    StringIdentityUserRoleFromJSON,
    StringIdentityUserRoleToJSON,
} from '../models';

export interface ApiAdminUserRoleGetRequest {
    filter?: string;
    range?: string;
    sort?: string;
}

export interface ApiAdminUserRoleIdDeleteRequest {
    id: number;
}

export interface ApiAdminUserRoleIdGetRequest {
    id: number;
}

export interface ApiAdminUserRoleIdPutRequest {
    id: number;
    stringIdentityUserRole?: StringIdentityUserRole;
}

export interface ApiAdminUserRolePostRequest {
    stringIdentityUserRole?: StringIdentityUserRole;
}

/**
 * 
 */
export class AdminUserRoleApi extends runtime.BaseAPI {

    /**
     */
    async apiAdminUserRoleGetRaw(requestParameters: ApiAdminUserRoleGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<StringIdentityUserRole>>> {
        const queryParameters: any = {};

        if (requestParameters.filter !== undefined) {
            queryParameters['filter'] = requestParameters.filter;
        }

        if (requestParameters.range !== undefined) {
            queryParameters['range'] = requestParameters.range;
        }

        if (requestParameters.sort !== undefined) {
            queryParameters['sort'] = requestParameters.sort;
        }

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/userRole`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(StringIdentityUserRoleFromJSON));
    }

    /**
     */
    async apiAdminUserRoleGet(requestParameters: ApiAdminUserRoleGetRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<StringIdentityUserRole>> {
        const response = await this.apiAdminUserRoleGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminUserRoleIdDeleteRaw(requestParameters: ApiAdminUserRoleIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<StringIdentityUserRole>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminUserRoleIdDelete.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/userRole/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => StringIdentityUserRoleFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminUserRoleIdDelete(requestParameters: ApiAdminUserRoleIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<StringIdentityUserRole> {
        const response = await this.apiAdminUserRoleIdDeleteRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminUserRoleIdGetRaw(requestParameters: ApiAdminUserRoleIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<StringIdentityUserRole>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminUserRoleIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/userRole/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => StringIdentityUserRoleFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminUserRoleIdGet(requestParameters: ApiAdminUserRoleIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<StringIdentityUserRole> {
        const response = await this.apiAdminUserRoleIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminUserRoleIdPutRaw(requestParameters: ApiAdminUserRoleIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<StringIdentityUserRole>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminUserRoleIdPut.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/userRole/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: StringIdentityUserRoleToJSON(requestParameters.stringIdentityUserRole),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => StringIdentityUserRoleFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminUserRoleIdPut(requestParameters: ApiAdminUserRoleIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<StringIdentityUserRole> {
        const response = await this.apiAdminUserRoleIdPutRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminUserRolePostRaw(requestParameters: ApiAdminUserRolePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<StringIdentityUserRole>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/userRole`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: StringIdentityUserRoleToJSON(requestParameters.stringIdentityUserRole),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => StringIdentityUserRoleFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminUserRolePost(requestParameters: ApiAdminUserRolePostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<StringIdentityUserRole> {
        const response = await this.apiAdminUserRolePostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}