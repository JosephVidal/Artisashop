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
  ProductImage,
} from '../models';
import {
    ProductImageFromJSON,
    ProductImageToJSON,
} from '../models';

export interface ApiAdminProductImageGetRequest {
    filter?: string;
    range?: string;
    sort?: string;
}

export interface ApiAdminProductImageIdDeleteRequest {
    id: number;
}

export interface ApiAdminProductImageIdGetRequest {
    id: number;
}

export interface ApiAdminProductImageIdPutRequest {
    id: number;
    productImage?: ProductImage;
}

export interface ApiAdminProductImagePostRequest {
    productImage?: ProductImage;
}

/**
 * 
 */
export class AdminProductImageApi extends runtime.BaseAPI {

    /**
     */
    async apiAdminProductImageGetRaw(requestParameters: ApiAdminProductImageGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<Array<ProductImage>>> {
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
            path: `/api/admin/productImage`,
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => jsonValue.map(ProductImageFromJSON));
    }

    /**
     */
    async apiAdminProductImageGet(requestParameters: ApiAdminProductImageGetRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<Array<ProductImage>> {
        const response = await this.apiAdminProductImageGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminProductImageIdDeleteRaw(requestParameters: ApiAdminProductImageIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ProductImage>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminProductImageIdDelete.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/productImage/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'DELETE',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ProductImageFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminProductImageIdDelete(requestParameters: ApiAdminProductImageIdDeleteRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ProductImage> {
        const response = await this.apiAdminProductImageIdDeleteRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminProductImageIdGetRaw(requestParameters: ApiAdminProductImageIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ProductImage>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminProductImageIdGet.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/productImage/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'GET',
            headers: headerParameters,
            query: queryParameters,
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ProductImageFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminProductImageIdGet(requestParameters: ApiAdminProductImageIdGetRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ProductImage> {
        const response = await this.apiAdminProductImageIdGetRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminProductImageIdPutRaw(requestParameters: ApiAdminProductImageIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ProductImage>> {
        if (requestParameters.id === null || requestParameters.id === undefined) {
            throw new runtime.RequiredError('id','Required parameter requestParameters.id was null or undefined when calling apiAdminProductImageIdPut.');
        }

        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/productImage/{id}`.replace(`{${"id"}}`, encodeURIComponent(String(requestParameters.id))),
            method: 'PUT',
            headers: headerParameters,
            query: queryParameters,
            body: ProductImageToJSON(requestParameters.productImage),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ProductImageFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminProductImageIdPut(requestParameters: ApiAdminProductImageIdPutRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ProductImage> {
        const response = await this.apiAdminProductImageIdPutRaw(requestParameters, initOverrides);
        return await response.value();
    }

    /**
     */
    async apiAdminProductImagePostRaw(requestParameters: ApiAdminProductImagePostRequest, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<runtime.ApiResponse<ProductImage>> {
        const queryParameters: any = {};

        const headerParameters: runtime.HTTPHeaders = {};

        headerParameters['Content-Type'] = 'application/json';

        if (this.configuration && this.configuration.apiKey) {
            headerParameters["Authorization"] = this.configuration.apiKey("Authorization"); // Bearer authentication
        }

        const response = await this.request({
            path: `/api/admin/productImage`,
            method: 'POST',
            headers: headerParameters,
            query: queryParameters,
            body: ProductImageToJSON(requestParameters.productImage),
        }, initOverrides);

        return new runtime.JSONApiResponse(response, (jsonValue) => ProductImageFromJSON(jsonValue));
    }

    /**
     */
    async apiAdminProductImagePost(requestParameters: ApiAdminProductImagePostRequest = {}, initOverrides?: RequestInit | runtime.InitOverrideFunction): Promise<ProductImage> {
        const response = await this.apiAdminProductImagePostRaw(requestParameters, initOverrides);
        return await response.value();
    }

}
