import LoginHomePage from '../e2e/testItau/loginHome'


LoginHomePage.visit();

describe('Listar Listas de Itens',()=>{

    it('Navegar Até Seção de Listar', ()=>{

       cy.get('botaoListar').click()
       cy.url().expect('INSIRA URL DE LISTAR AQUI')

    })

    it('Listar Itens', ()=>[

        cy.get('botaoListarListar').click(),
        cy.contains('tabelaListar'),
        cy.url().expect('INSIRA URL DE SUCESSO AQUI'),
        cy.get('botaoInicio').click()
    ])
})