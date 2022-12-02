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

export interface AdminUserRoleAdminUserRoleGetRequest {
    filter?: string;
    range?: string;
    sort?: string;
}

export interface AdminUserRoleAdminUserRoleIdDeleteRequest {
    id: number;
}

export interface AdminUserRoleAdminUserRoleIdGetRequest {
    id: number;
}

export interface AdminUserRoleAdminUserRoleIdPutRequest {
    id: number;
    stringIdentityUserRole?: StringIdentityUserRole;
}

export interface AdminUserRoleAdminUserRolePostRequest {
    stringIdentityUserRole?: StringIdentityUserRole;
}

/**
 * 
 */
export class AdminUserRoleApi extends runtime.BaseAPI {

    /**
     */
    async adminUserRoleAdminUserRoleGetRaw(requestParameters: AdminUserRoleAdminUserRoleGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<StringIdentityUserRole>>> {
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
            path: `/admin/userRole/AdminUserRole`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(StringIdentityUserRoleFromJSON));
    }

    /**
     */
    async adminUserRoleAdminUserRoleGet(requestParameters: AdminUserRoleAdminUserRoleGetRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<StringIdentityUserRole>> {
        const response = await this.adminUserRoleAdminUserRoleGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async adminUserRoleAdminUserRoleIdDeleteRaw(requestParameters: AdminUserRoleAdminUserRoleIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<StringIdentityUserRole>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling adminUserRoleAdminUserRoleIdDelete.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/admin/userRole/AdminUserRole/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => StringIdentityUserRoleFromJSON(jsonValue));
    }

    /**
     */
    async adminUserRoleAdminUserRoleIdDelete(requestParameters: AdminUserRoleAdminUserRoleIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<StringIdentityUserRole> {
        const response = await this.adminUserRoleAdminUserRoleIdDeleteRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async adminUserRoleAdminUserRoleIdGetRaw(requestParameters: AdminUserRoleAdminUserRoleIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<StringIdentityUserRole>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling adminUserRoleAdminUserRoleIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/admin/userRole/AdminUserRole/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => StringIdentityUserRoleFromJSON(jsonValue));
    }

    /**
     */
    async adminUserRoleAdminUserRoleIdGet(requestParameters: AdminUserRoleAdminUserRoleIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<StringIdentityUserRole> {
        const response = await this.adminUserRoleAdminUserRoleIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async adminUserRoleAdminUserRoleIdPutRaw(requestParameters: AdminUserRoleAdminUserRoleIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<StringIdentityUserRole>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling adminUserRoleAdminUserRoleIdPut.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/admin/userRole/AdminUserRole/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: StringIdentityUserRoleToJSON(requestParameters.stringIdentityUserRole),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => StringIdentityUserRoleFromJSON(jsonValue));
    }

    /**
     */
    async adminUserRoleAdminUserRoleIdPut(requestParameters: AdminUserRoleAdminUserRoleIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<StringIdentityUserRole> {
        const response = await this.adminUserRoleAdminUserRoleIdPutRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async adminUserRoleAdminUserRolePostRaw(requestParameters: AdminUserRoleAdminUserRolePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<StringIdentityUserRole>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/admin/userRole/AdminUserRole`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: StringIdentityUserRoleToJSON(requestParameters.stringIdentityUserRole),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => StringIdentityUserRoleFromJSON(jsonValue));
    }

    /**
     */
    async adminUserRoleAdminUserRolePost(requestParameters: AdminUserRoleAdminUserRolePostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<StringIdentityUserRole> {
        const response = await this.adminUserRoleAdminUserRolePostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
