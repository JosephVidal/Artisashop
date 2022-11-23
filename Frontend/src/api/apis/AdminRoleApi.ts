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
  IdentityRole,
} from '../models';
import {
    IdentityRoleFromJSON,
    IdentityRoleToJSON,
} from '../models';

export interface ApiAdminRoleGetRequest {
    filter?: string;
    range?: string;
    sort?: string;
}

export interface ApiAdminRoleIdDeleteRequest {
    id: number;
}

export interface ApiAdminRoleIdGetRequest {
    id: number;
}

export interface ApiAdminRoleIdPutRequest {
    id: number;
    identityRole?: IdentityRole;
}

export interface ApiAdminRolePostRequest {
    identityRole?: IdentityRole;
}

/**
 * 
 */
export class AdminRoleApi extends runtime.BaseAPI {

    /**
     */
    async apiAdminRoleGetRaw(requestParameters: ApiAdminRoleGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<IdentityRole>>> {
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
            path: `/api/admin/role`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(IdentityRoleFromJSON));
    }

    /**
     */
    async apiAdminRoleGet(requestParameters: ApiAdminRoleGetRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<IdentityRole>> {
        const response = await this.apiAdminRoleGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminRoleIdDeleteRaw(requestParameters: ApiAdminRoleIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<IdentityRole>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminRoleIdDelete.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/role/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => IdentityRoleFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminRoleIdDelete(requestParameters: ApiAdminRoleIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<IdentityRole> {
        const response = await this.apiAdminRoleIdDeleteRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminRoleIdGetRaw(requestParameters: ApiAdminRoleIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<IdentityRole>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminRoleIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/role/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => IdentityRoleFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminRoleIdGet(requestParameters: ApiAdminRoleIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<IdentityRole> {
        const response = await this.apiAdminRoleIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminRoleIdPutRaw(requestParameters: ApiAdminRoleIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<IdentityRole>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminRoleIdPut.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/role/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: IdentityRoleToJSON(requestParameters.identityRole),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => IdentityRoleFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminRoleIdPut(requestParameters: ApiAdminRoleIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<IdentityRole> {
        const response = await this.apiAdminRoleIdPutRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminRolePostRaw(requestParameters: ApiAdminRolePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<IdentityRole>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/role`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: IdentityRoleToJSON(requestParameters.identityRole),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => IdentityRoleFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminRolePost(requestParameters: ApiAdminRolePostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<IdentityRole> {
        const response = await this.apiAdminRolePostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
