import { CardsService } from "./cards.service"
import { HttpTestingController, provideHttpClientTesting} from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';
import { TestBed } from "@angular/core/testing";
import { Cards } from "./cards.model";
import exp from "constants";


describe('CardsService', ()=>{
    let cardsService: CardsService;
    let httpMock: HttpTestingController;

    beforeEach(() => {
        TestBed.configureTestingModule({
            providers: [
                CardsService,
                provideHttpClient(),
                provideHttpClientTesting()
            ]
        });
        cardsService = TestBed.inject(CardsService);
        httpMock = TestBed.inject(HttpTestingController);
    });

    it('should be created', () => {
        expect(cardsService).toBeTruthy();
    });

    it('should get all cards', () => {
        const cardsAll: Cards[] = [
            {cardId:'35db87b6-c6aa-4526-9a6a-c68d80ed1628', question:'q1', answer:'a1', status:'pass'},
            {cardId:'8890a3a0-5cd0-45a7-b293-06b6e5736114', question:'q2', answer:'a2', status:'pass'}
        ];
        cardsService.getAllCards().subscribe((cards: Cards[]) => {
            expect(cards.length).toBe(2);
            expect(cards).toEqual(cardsAll);
        });
        const url = `${cardsService.baseUrl}/cards`;
        const req = httpMock.expectOne(url);
        expect(req.request.method).toBe('GET');
        req.flush(cardsAll);
    });
})