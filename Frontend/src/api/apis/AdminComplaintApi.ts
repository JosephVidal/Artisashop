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
  Complaint,
} from '../models';
import {
    ComplaintFromJSON,
    ComplaintToJSON,
} from '../models';

export interface ApiAdminComplaintGetRequest {
    filter?: string;
    range?: string;
    sort?: string;
}

export interface ApiAdminComplaintIdDeleteRequest {
    id: number;
}

export interface ApiAdminComplaintIdGetRequest {
    id: number;
}

export interface ApiAdminComplaintIdPutRequest {
    id: number;
    complaint?: Complaint;
}

export interface ApiAdminComplaintPostRequest {
    complaint?: Complaint;
}

/**
 * 
 */
export class AdminComplaintApi extends runtime.BaseAPI {

    /**
     */
    async apiAdminComplaintGetRaw(requestParameters: ApiAdminComplaintGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<Complaint>>> {
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
            path: `/api/admin/complaint`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(ComplaintFromJSON));
    }

    /**
     */
    async apiAdminComplaintGet(requestParameters: ApiAdminComplaintGetRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<Complaint>> {
        const response = await this.apiAdminComplaintGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminComplaintIdDeleteRaw(requestParameters: ApiAdminComplaintIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Complaint>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminComplaintIdDelete.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/complaint/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ComplaintFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminComplaintIdDelete(requestParameters: ApiAdminComplaintIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Complaint> {
        const response = await this.apiAdminComplaintIdDeleteRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminComplaintIdGetRaw(requestParameters: ApiAdminComplaintIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Complaint>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminComplaintIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/complaint/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ComplaintFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminComplaintIdGet(requestParameters: ApiAdminComplaintIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Complaint> {
        const response = await this.apiAdminComplaintIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminComplaintIdPutRaw(requestParameters: ApiAdminComplaintIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Complaint>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminComplaintIdPut.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/complaint/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: ComplaintToJSON(requestParameters.complaint),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ComplaintFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminComplaintIdPut(requestParameters: ApiAdminComplaintIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Complaint> {
        const response = await this.apiAdminComplaintIdPutRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminComplaintPostRaw(requestParameters: ApiAdminComplaintPostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Complaint>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/complaint`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: ComplaintToJSON(requestParameters.complaint),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ComplaintFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminComplaintPost(requestParameters: ApiAdminComplaintPostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Complaint> {
        const response = await this.apiAdminComplaintPostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
