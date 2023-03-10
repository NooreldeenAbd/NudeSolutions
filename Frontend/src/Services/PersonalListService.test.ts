import { describe, test, vi, expect } from 'vitest'
import axios from 'axios';
import PersonalListService from './PersonalListService'

describe('Personal List Service', () => {

    const mockGet = vi.spyOn(axios, 'get');
    const mockPost = vi.spyOn(axios, 'post');
    const mockDelete = vi.spyOn(axios, 'delete');
    const mockData = [
        {
            id: 1,
            name: "1",
            value: 100,
            categoryId: 1
        },
        {
            id: 2,
            name: "2",
            value: 200,
            categoryId: 1
        },
        {
            id: 3,
            name: "3",
            value: 300,
            categoryId: 3
        }
    ]

    test('Should Get List', async () => {
        mockGet.mockImplementation((url) => { return Promise.resolve({ data: mockData }); })
        const res = await PersonalListService.GetList();
        expect(mockGet).toHaveBeenCalledOnce();
        expect(res.length).toBe(3);
    });

    test('Should Post Item', async () => {

        mockPost.mockImplementation((url) => { return Promise.resolve({ data: mockData[0].id }); })
        const res = await PersonalListService.PostItem(mockData[0]);
        expect(mockPost).toHaveBeenCalledOnce();
        expect(res).toBe(mockData[0].id);
    });

    test('Should Delete Item', async () => {
        mockDelete.mockImplementation((url) => { return Promise.resolve({ data: true }); })
        const res = await PersonalListService.DeleteItem(mockData[0].id);
        expect(mockDelete).toHaveBeenCalledOnce();
        expect(res).toBeTruthy();
    });
});